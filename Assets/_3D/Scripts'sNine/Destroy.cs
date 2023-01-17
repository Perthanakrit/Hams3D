using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    //put this on the particle effect prefab
    //make sure the prefab has rigidbody with gravity turned off
    //and also box collider
    [SerializeField] float time;
    public GameObject clone;

    void Start()
    {
        Destroy(clone, time);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Destroy(clone);
        Debug.Log("Hitted");
    }*/
}
