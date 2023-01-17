using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class UiInfo
{
    public TextMeshProUGUI Tittle;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Point;
}


public class QuestsDisplay : MonoBehaviour
{
    [SerializeField] List<UiInfo> information = new List<UiInfo>();

    [SerializeField] List<Quests> questsInfo = new List<Quests>();
    
    void Start()
    {
       

        for (int i=0; i < questsInfo.Count; i++)
        {
            if (i == questsInfo.Count) return;
            information[i].Tittle.text = questsInfo[i].title;
            information[i].Description.text = questsInfo[i].description;
            information[i].Point.text = "0" + "/" + questsInfo[i].NumofKillingToComplete.ToString();
         
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int j=0; j < questsInfo.Count; j++)
        {
            information[j].Point.text = questsInfo[j].currQuantity.ToString() + "/" + questsInfo[j].NumofKillingToComplete.ToString();
            DeleteQuestAfterQuestComplete(j);
        }   
    }

    void DeleteQuestAfterQuestComplete(int index)
    {
        if (questsInfo[index].isCompleted) 
            information[index].Point.text = "Completed";
    }
}
