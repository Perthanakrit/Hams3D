using System.Collections.Generic;
using UnityEngine;

public class DamageDealerErikaArcher : MonoBehaviour
{
    public LayerMask Enemy;

    public bool canDealDamage;
    public List<GameObject> hasDealtDamage;

    public float weaponLength;
    [SerializeField] private CharacterList character;
    public float weaponDamage;
    void Start()
    {
        weaponDamage = character.strength;
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
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
                }
            }
        }
       
    }
    /*public void StartDealDamageErika()
    {
        Debug.Log("Damage");
        canDealDamage = true;
        hasDealtDamage.Clear();
    }
    public void EndDealDamageErika()
    {
        canDealDamage = false;
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}