using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("plaen"))
        {
            
            Destroy(gameObject,1f);  

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
