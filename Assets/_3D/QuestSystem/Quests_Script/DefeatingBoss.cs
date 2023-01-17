using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatingBoss : MonoBehaviour
{
    [SerializeField] Quests _quest;
    [SerializeField]private GameObject[] emenyArr;
    public List<GameObject> Enemies = new List<GameObject>();

    [HideInInspector] public int numofkilldedEnemies;
    [SerializeField] private int numofBoss;

    private void Awake()
    {
        numofkilldedEnemies = 0;
        _quest.currQuantity = numofkilldedEnemies;
        _quest.isCompleted = false;
       

    }
    void Start()
    {
        
    }

    void Update()
    {
        FindBody();
        ThisIsComplete();
    }

    void ThisIsComplete()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i] == null)
            {
                Enemies.RemoveAt(i);
                numofkilldedEnemies++;
                _quest.currQuantity = numofkilldedEnemies;
            }
        }
        if (numofkilldedEnemies == _quest.NumofKillingToComplete) QuestManager.instance.CompleteQuest(_quest.name);
    }

    void FindBody()
    {
        emenyArr = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in emenyArr)
        {
            
            if (numofBoss > Enemies.Count && enemy.GetComponent<EnemyBoss>() != null)
            {
                Enemies.Add(enemy);
                //numofBoss++;
            }
                     
        }
    }
}
