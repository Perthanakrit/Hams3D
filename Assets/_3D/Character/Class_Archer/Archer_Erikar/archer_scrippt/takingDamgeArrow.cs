using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takingDamgeArrow : MonoBehaviour
{
    [SerializeField] private CharacterList character;
    [SerializeField] private int num;
    [SerializeField] bool isAbility;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isAbility)
            {
                var damage = character.skills[num].damage;
                collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
            else
            {
                var damage = (character.strength) / 10;
                collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
            
        }
    }
}
