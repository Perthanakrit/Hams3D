using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private CharacterList character;
    private float maxHealth;
    public float health;
    //public float attackDmg;
    //public float attackSpeed;
    //public float attackTime;

    skeletonAttack skeletonAttackScript;

    void Start()
    {
        //skeletonAttackScript = GameObject.FindGameObjectWithTag("Player").GetComponent<skeletonAttack>();
        health = character.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
