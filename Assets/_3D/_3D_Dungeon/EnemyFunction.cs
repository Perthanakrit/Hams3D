using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using commanastationwww.eternaltemple;

public class EnemyFunction : MonoBehaviour
{
    [SerializeField] GameObject EnemySpawn;
    Door_Controller door;
    [SerializeField] LayerMask player;
    [SerializeField] float Maxdistance;
    public bool EnemiesIsActive;
    private float elaspedTime;
    void Start()
    {
        door = FindObjectOfType<Door_Controller>();
    }

    private void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
  
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Maxdistance, player))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            
            if (!EnemiesIsActive) 
            {
                StartCoroutine(AboutToBeDisabled(true, 0.5f));
                
            }
            else if (EnemiesIsActive)
            {   
                StartCoroutine(AboutToBeDisabled(false, 1f));
            }
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * Maxdistance, Color.red);  
        }
        
        
    }

    IEnumerator AboutToBeDisabled(bool active, float time)
    {
        yield return new WaitForSeconds(time);
        EnemiesIsActive = active;
        EnemySpawn.SetActive(active);
    }

    /*private void OnDrawGizmos()
    {
        RaycastHit hit;

        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.right) * Maxdistance;
        Gizmos.DrawRay(transform.position, direction);
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Maxdistance, player))
        {
            Gizmos.color = Color.green;
        }
    }*/

}