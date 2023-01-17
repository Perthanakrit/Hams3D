using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireonPlane : MonoBehaviour
{
    public trap _trap; //Import from trap.cs
    //public detectDamage _detectDamage; 

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag  == "fireBall")
        {
            _trap.pSys.Play();
           // _detectDamage.beInFire = true;
        }else{
            _trap.pSys.Stop();
        }
    }
    void Start()
    {
        _trap.pSys.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
