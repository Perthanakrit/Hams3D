using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WhichEnemy : MonoBehaviour
{
    public static WhichEnemy enemy { get ; private set; }
    [SerializeField] private erika_Combat enemyArrray;
    private int idObj;
    private GameObject[] arrayEe;

    void Start()
    {
        enemy = this;
        arrayEe = enemyArrray.enemys;
    }
    public void WhichEnemyDead(int enemydead)
    {
 
        for(int e = 0; e < arrayEe.Length; e++)
        {
            idObj = arrayEe[e].GetInstanceID();
            if (idObj == enemydead)
            {
                Debug.Log("Enemy" + enemydead);
                RemoveElement(ref arrayEe, e);
            }
        }

    }
    void RemoveElement<T>(ref T[] arr, int index)
    {
        for (int i = index; i < arr.Length - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        Array.Resize(ref arr, arr.Length - 1);
    }
}
