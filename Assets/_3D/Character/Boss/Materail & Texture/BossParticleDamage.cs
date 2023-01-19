using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossParticleDamage : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    //private List<ParticleCollisionEvent> colEvent;
    [SerializeField] private float damage;
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Play();
    }
    private void Update()
    {
        
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out HealthSystem player))
        {
            Debug.Log("JumpAttack damge : " + damage);
            player.TakeDamage(damage);
        }
    }
}
