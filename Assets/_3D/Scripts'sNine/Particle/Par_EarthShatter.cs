using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Par_EarthShatter : MonoBehaviour
{
    [SerializeField] float earthshatterDamage;
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(earthshatterDamage);
            Debug.Log("hitttttttttttttttttttt");
        }

        Debug.Log("Didn't hit");
    }*/

    public ParticleSystem _particleSystem;
    //public bool enter;

    private void OnEnable()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    /*private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Play();
    }*/

    /*List<ParticleCollisionEvent> colEvent = new List<ParticleCollisionEvent> ();
    private void OnParticleCollision(GameObject other)
    {
        int events = _particleSystem.GetCollisionEvents(other, colEvent);
        Debug.Log("Hittttttttttt");

        for (int i = 0; i < events; i++)
        {

        }

        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(earthshatterDamage);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(earthshatterDamage);
        }
    }

    /*private void OnParticleTrigger(Collider other)
    {
        if (enter)
        {
            List<GameObject> enterList = new List<GameObject>();
            GameObject gameobjectEnter = _particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterList);
            
            for (int i = 0; i < numEnter; i++)
            {
                ParticleSystem.Particle p = enterList[i];
                p.startColor = new Color32(255, 0, 0, 255);
                enterList[i] = p;
                
            }
            if (gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(earthshatterDamage);
            }

            _particleSystem.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterList);
            
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(earthshatterDamage);
        }

    }*/
    
}
