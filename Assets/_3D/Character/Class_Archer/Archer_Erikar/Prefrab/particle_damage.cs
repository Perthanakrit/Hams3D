using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_damage : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem _particleSystem;
    [SerializeField] private CharacterList character;    //private List<ParticleCollisionEvent> colEvent;
    private float damage;
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Play();
        damage = character.skills[2].damage;
        
    }

    private void OnParticleCollision(GameObject other)
    {
        
        //int events = particleSystem.GetCollisionEvents(other, colEvent);
        //Debug.Log("Hittttttttttt");

        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);

        }
    }
        
}
