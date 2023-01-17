using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

//[CreateAssetMenu(menuName = "QuestSys/quest_test")]
public class Quest_test : ScriptableObject
{
    [System.Serializable]
    public struct Info
    {
        public string Name;
        public Sprite Item;
        public string Descripton;
    }
    #region Variable
    [Header("Info")] public Info Information;

    public struct Stat
    {
        public int Currency;
        public int XP;
    }

    [Header("Reward")] public Stat Reward = new Stat { Currency = 10, XP = 10 };

    public bool Completed { get; protected set; }
    public QuestCompletedEvent QuestComplete;
    #endregion

    public abstract class QuestGoal : ScriptableObject
    {
        protected string Description;
        public int CurrentAmout { get; protected set; }
        public int RequiredAmout = 1;

        public bool Completed { get; protected set; }
        [HideInInspector] public UnityEvent GoalCompleted;

        public virtual string GetDescription()
        {
            return Description;
        }
        public virtual void Initialize()
        {
            Completed = false;

        }
        
        protected void Evaluate()
        {
            if (CurrentAmout >= RequiredAmout)
            {
                Complete();
            }
        }
        private void Complete()
        {
            Completed = true;
            GoalCompleted.Invoke();
            GoalCompleted.RemoveAllListeners();
        }
    }

    public List<QuestGoal> Goals;

    public void Initialize()
    {
        Completed = false;
        QuestComplete = new QuestCompletedEvent();

        foreach (var goal in Goals)
        {
            goal.Initialize();
            goal.GoalCompleted.AddListener(delegate { CheckGoals(); });
        }
    }
    private void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
        if (Completed)
        {
            //give reward
            QuestComplete.Invoke(this);
            QuestComplete.RemoveAllListeners();
        }
    }
}

public class QuestCompletedEvent : UnityEvent<Quest_test> { }


#if UNITY_EDITOR
[CustomEditor(typeof(Quest_test))]
public class QuestEditior : Editor
{
    SerializedProperty m_QuestInfoProperty;
    SerializedProperty m_QuestStatProperty;

    List<string> m_QuestGoalType;
    SerializedProperty m_QuestGoalListsProperty;

    [MenuItem("Assets/Quest", priority =0)]
    public static void CreateQuest()
    {
        var newQuest = CreateInstance<Quest_test>();

        ProjectWindowUtil.CreateAsset(newQuest, "quest.asset");
    }

    private void OnEnable()
    {
        m_QuestGoalListsProperty = serializedObject.FindProperty(nameof(Quest_test.Information));
        m_QuestStatProperty = serializedObject.FindProperty(nameof(Quest_test.Reward));

        m_QuestGoalListsProperty = serializedObject.FindProperty(nameof(Quest_test.Goals));

        var lookup = typeof(Quest_test.QuestGoal);
        m_QuestGoalType = System.AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(lookup))
            .Select(type  => type.Name)
            .ToList();
    }

    public override void OnInspectorGUI()
    {
        var child = m_QuestInfoProperty.Copy();
        var depth = child.depth;
        child.NextVisible(true);

        EditorGUILayout.LabelField("Quest info", EditorStyles.boldLabel);
        while (child.depth > depth)
        {
            EditorGUILayout.PropertyField(child, true);
            child.NextVisible(false);
        }

        child = m_QuestStatProperty.Copy();
        depth = child.depth;
        child.NextVisible(true);

        EditorGUILayout.LabelField("Quest reward", EditorStyles.boldLabel);
        while (child.depth > depth)
        {
            EditorGUILayout.PropertyField(child, true);
            child.NextVisible(false);
        }
        int choice = EditorGUILayout.Popup("Add new Quest Goal", -1, m_QuestGoalType.ToArray());

        if (choice != -1)
        {
            var newInstance = ScriptableObject.CreateInstance(m_QuestGoalType[choice]);

            AssetDatabase.AddObjectToAsset(newInstance, target);

            m_QuestGoalListsProperty.InsertArrayElementAtIndex(m_QuestGoalListsProperty.arraySize);
            m_QuestGoalListsProperty.GetArrayElementAtIndex(m_QuestGoalListsProperty.arraySize - 1)
                .objectReferenceValue = newInstance;
        }

        Editor ed = null;
        int toDelete = -1;
        for (int i = 0; i < m_QuestGoalListsProperty.arraySize; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical();
            var item = m_QuestGoalListsProperty.GetArrayElementAtIndex(i);
            SerializedObject obj = new SerializedObject(item.objectReferenceValue);

            Editor.CreateCachedEditor(item.objectReferenceValue, null, ref ed);

            ed.OnInspectorGUI();
            EditorGUILayout.EndVertical();

            if (GUILayout.Button("-", GUILayout.Width(32)))
            {
                toDelete = i;
            }
            EditorGUILayout.EndHorizontal();
        }

        if (toDelete != -1)
        {
            var item = m_QuestGoalListsProperty.GetArrayElementAtIndex(toDelete).objectReferenceValue;
            DestroyImmediate(item, true);

            m_QuestGoalListsProperty.DeleteArrayElementAtIndex(toDelete);
            m_QuestGoalListsProperty.DeleteArrayElementAtIndex(toDelete);
        }

        serializedObject.ApplyModifiedProperties();

    }

}
#endif