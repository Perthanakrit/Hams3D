using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_newfloor : MonoBehaviour
{

    [SerializeField] List<GameObject> enemys;
    private void Start()
    {

    }
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            foreach (GameObject enemy in enemys)
            {

            }
           
        }
    }
}
