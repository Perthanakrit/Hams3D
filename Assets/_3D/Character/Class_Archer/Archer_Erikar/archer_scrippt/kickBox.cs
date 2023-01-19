using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kickBox : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform perFab;
    [SerializeField] private Transform spwan;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void boxInstantiate()
    {
        Instantiate(perFab, spwan.position, spwan.rotation);
    }
}
