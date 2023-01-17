using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public LayerMask Enemy;
    public GameObject dir_Knockback_viagameobject;

    bool canDealDamage;
    List<GameObject> hasDealtDamage;

    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;
    [SerializeField] private float knockbackStrenght;
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
        dir_Knockback_viagameobject = GameObject.FindGameObjectWithTag("Knockback_Dir");
    }

    void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, Enemy))
            {
                if (hit.transform.TryGetComponent(out Enemy enemy) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    enemy.TakeDamage(weaponDamage);
                    enemy.HitVFX(hit.point);
                    hasDealtDamage.Add(hit.transform.gameObject);

                    Rigidbody rb = hit.collider.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        rb.isKinematic = false;
                        rb.constraints = ~RigidbodyConstraints.FreezePositionZ & ~RigidbodyConstraints.FreezePositionX & ~RigidbodyConstraints.FreezePositionY;
                        Vector3 direction = hit.transform.position - dir_Knockback_viagameobject.transform.position;
                        direction.y = 0;

                        rb.AddForce(direction.normalized * knockbackStrenght, ForceMode.Impulse);
                        Debug.Log("knock back");
                    }

                }
            }
        }
    }
    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage.Clear();
    }
    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}