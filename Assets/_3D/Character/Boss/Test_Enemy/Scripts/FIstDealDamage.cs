using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIstDealDamage : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] SphereCollider _collider;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HealthSystem>() != null && collision.gameObject.CompareTag("Player"))
        {
             collision.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
            _collider.enabled = !_collider.enabled;
        }
    }

    public void ColliderEnable()
    {
        _collider.enabled = true;
    }

}
