using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExoplodeForce : MonoBehaviour
{
    [SerializeField] private GameObject parti;
    [SerializeField] private Transform point;
    //[SerializeField] private GameObject prefab;
    //public ParticleSystem partSys;
    [SerializeField] private int explodeForec;
    [SerializeField] private int radius;
    //[SerializeField] private Transform point;
    private groundVFX vfx;
    void Start()
    {
        vfx = GetComponent<groundVFX>();
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ExplosionForce");
        explosionForce();
        //Instantiate(parti, point.position, Quaternion.identity);
        
    }

    public void explosionForce()
    {
        //float distance = Vector3.Distance(transform.position, fov.visibleTarget.position);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearby in colliders)
        {
            Rigidbody rigibody = nearby.GetComponent<Rigidbody>();
            if (rigibody != null)
            {
                if (nearby.CompareTag("Player")) { Debug.Log("ExplosionForce_Player"); }
                rigibody.AddExplosionForce(explodeForec, transform.position, radius, 2.5f, ForceMode.Impulse);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
/*
   อาจจะซ้อม persent เดือน Jan 
 */