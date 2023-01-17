using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Collectible;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxhealth = 3;
    [SerializeField] private HealthBar _EhealthBar;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject ragdoll;
    [SerializeField] bool notBoss;
    [HideInInspector] public float currenthealth;
    private Spawning _spawning;
    int idEnemy;

    [SerializeField] Animator animator;

    private void Awake()
    {
        idEnemy = gameObject.GetInstanceID();
        currenthealth = maxhealth;
    }

    void Start()
    {
        if(notBoss)_EhealthBar.UpdateHealthBar(maxhealth, currenthealth);
        animator = this.GetComponent<Animator>();
        _spawning = GetComponent<Spawning>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currenthealth <= 0)
        {
            currenthealth = 0;
            _spawning.SpawnCollectible(transform);
            Die();
        }
    }

    bool? CheckPlayer(GameObject [] players) 
    { 
        foreach(GameObject player in players)  { if (player.GetComponent<erika_Combat>()) return true; }
        return null;
    }

    void Die()
    {
        if (CheckPlayer(GameObject.FindGameObjectsWithTag("Player")) != null) erika_Combat.Instance.WhichEnemyDead(idEnemy);
        Instantiate(ragdoll, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void TakeDamage(float damageAmount)
    {
        CameraShake.Instance.ShakeCamera(4f, 0.2f);
        Debug.Log("Get Hitttttttttttttttttt");
        currenthealth -= damageAmount;
        Invoke("afterknockback", 0.75f);
        if (notBoss) animator.SetTrigger("damage");
        _EhealthBar.UpdateHealthBar(maxhealth,currenthealth);
        
    }
    public void EnemyStartDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().EnemyStartDealDamage();
    }
    public void EnemyEndDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().EnemyEndDealDamage();
    }

    public void HitVFX(Vector3 hitPosition)
    {
        GameObject hit = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        Destroy(hit, 3f);
    }

    private void afterknockback()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.isKinematic = true;
    }
}