using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActive_Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject explosion;
    [SerializeField] private Transform explode;
    void Start()
    {
        Instantiate(explosion, explode.position, explode.rotation);
    }
    void Update()
    {
        
    }

    // Update is called once per frame

}
