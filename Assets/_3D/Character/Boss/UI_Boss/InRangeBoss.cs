using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InRangeBoss : MonoBehaviour
{
    [SerializeField] List<GameObject> SysInRangeBoss = new List<GameObject>();
    enum detectPlayer
    {
        enter, exit
    }

    detectPlayer player;
    
    private float calculatehp = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        player = detectPlayer.enter;
        StartCoroutine(ActiveEveryThingInRangeBoss(2.5f));
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;
        player = detectPlayer.exit;
        StartCoroutine(ActiveEveryThingInRangeBoss(0.5f));
    }

    private void Start()
    {
        SysInRangeBoss[2].SetActive(false);
    }

    IEnumerator ActiveEveryThingInRangeBoss(float time)
    {
        yield return new WaitForSeconds(time);
        for (int i= 0; i < SysInRangeBoss.Count; i++)
        {
            if (player == detectPlayer.enter)
            {
                SysInRangeBoss[i].SetActive(true);
            }
            if (player == detectPlayer.exit)
            {
                SysInRangeBoss[i].SetActive(false);
            }
        }
        
    }
    
}
