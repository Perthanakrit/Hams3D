using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance { get; private set; }

    [SerializeField] private List<Quests> m_Quests = new List<Quests>();

    [SerializeField] private GameObject[] players;

    private void Awake()
    {
        instance = this;
    }
    
    public Quests GetQuestByName(string name)
    {
        // Search the list of quests for a quest with the specified name
        foreach (Quests quest in m_Quests)
        {
            Debug.Log(quest.name);
            if (quest.name == name)
            {
                return quest;
            }
        }

        // If no quest is found, return null
        return null;
    }

    public void CompleteQuest(string name)//For applying
    {
        Quests quest = GetQuestByName(name);
        Debug.Log(name); 
        if (quest != null)
        {    
            quest.CompleteQuest();
            GiveRewards();
        }
    }

    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        
    }
    class ScriptCharacter
    {
        Character_archer archer;
        Character mage;
        Character_Warrior warrior;
    }
    void GiveRewards()
    {
        for (int i=0; i < m_Quests.Count; i++)
        {
            if (m_Quests[i].isCompleted)
            {

                foreach (GameObject player in players)
                {
                    if (player.GetComponent< Character_archer>()) player.GetComponent<Character_archer>().Inventory.LuckyPower += m_Quests[i].LuckyKey;
                    //if (player.GetComponent<Character>()) player.GetComponent<Character>().Inventory.LuckyPower += m_Quests[i].LuckyKey;
                    //Character_Warrior
                }   

                m_Quests.RemoveAt(i);
            }
            
        }
    }
 
}
