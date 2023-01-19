using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collectible;

public class GetStamina : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] CollectibleSpawning stamina;
    // Update is called once per frame
    void Update()
    {
        Getting();
    }
    void Getting()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player")) 
            {
                collider.GetComponent<ManaSystem>().currentMana += stamina.mana;
                collider.GetComponent<HealthSystem>().currentHealth += stamina.Hp;
                Destroy(gameObject);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;
    }
}
