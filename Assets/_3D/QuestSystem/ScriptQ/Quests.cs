using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="QuestSys/Quest")]
public  class Quests : ScriptableObject
{
    public string title;
    public string description;
    public int NumofKillingToComplete;
    public bool isCompleted;
    public int currQuantity { get; set; }
    [Header("Reward")]
    public int LuckyKey;
    public Quests(string name, string description, int reward)
    {
        this.name = name;
        this.description = description;
        this.isCompleted = false;
    }

    public void CompleteQuest()
    {
        this.isCompleted = true;
        Debug.Log("Complete");
    }
   
    public void QuestOne()
    {
    }

}
