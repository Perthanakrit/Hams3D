using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestKillMonters : MonoBehaviour
{
    [SerializeField] Quests _quest;

    [SerializeField] GameObject[] emenyArr;   
    public List<GameObject> Enemies = new List<GameObject>();

    [HideInInspector] public int numofkilldedEnemies;

    private void Awake()
    {
        numofkilldedEnemies = 0;
        _quest.currQuantity = numofkilldedEnemies;
        _quest.isCompleted = false;
  
    }
    void Start()
    {
        //FindEnemies();
    }

    void Update()
    {
        FindEnemies();
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
        if(numofkilldedEnemies == _quest.NumofKillingToComplete) QuestManager.instance.CompleteQuest(_quest.name);
    }
    void FindEnemies()
    {
        emenyArr = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in emenyArr)
        {
            if (emenyArr.Length > Enemies.Count && enemy.GetComponent<Enemy>().currenthealth < 150f) Enemies.Add(enemy);
            
        }
    }
}
