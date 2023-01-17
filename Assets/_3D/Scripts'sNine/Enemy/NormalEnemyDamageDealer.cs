using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyDamageDealer : MonoBehaviour
{
    public LayerMask Player;

    bool canDealDamage;
    bool hasDealtDamage;

    [SerializeField] float weaponLength;
    public float weaponDamage;
   
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (canDealDamage && !hasDealtDamage)
        {
            //Debug.Log("0");
            RaycastHit hit;

            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, Player))
            {
                Debug.Log("1");
                if (hit.transform.TryGetComponent(out HealthSystem health))
                {
                    health.TakeDamage(weaponDamage);
                    health.HitVFX(hit.point);
                    hasDealtDamage = true;
                    Debug.Log("2");
                }
            }
        }
    }
    public void EnemyStartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage = false;
    }
    public void EnemyEndDealDamage()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}