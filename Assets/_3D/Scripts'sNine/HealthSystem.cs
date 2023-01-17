using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject ragdoll;
    public float currentHealth;
    public GameObject SpellPosition;
    public GameObject HealEffect;

    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    float colorSmoothing = 6f;
    bool isTakingDamage = false;
    bool playerDie = false;

    [SerializeField] private HPManaHandler _HPMNBar;
    Animator animator;

    Image[] firstList;
    string nameToLookFor = "DamageImage";

    void Start()
    {
        firstList = GameObject.FindObjectsOfType<Image>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        _HPMNBar = Camera.main.GetComponent<HPManaHandler>();

        for (var i = 0; i < firstList.Length; i++)
        {
            if (firstList[i].gameObject.name == nameToLookFor)
            {
                //finalList.Add(firstList[i]);
                damageImage = firstList[i];
            }
        }

    }

    private void Update()
    {
        if(isTakingDamage)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, colorSmoothing * Time.deltaTime);
        }
        isTakingDamage = false;
        
        if (currentHealth >= 100) currentHealth = 100;

        _HPMNBar.UpdateHPBar(maxHealth, currentHealth);

    }

    public void TakeDamage(float damageAmount)
    {
        isTakingDamage = true;
        currentHealth -= damageAmount;
        CameraShake.Instance.ShakeCamera(4f, 0.2f);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }

    public void GetHeal(float heal)
    {
        //animator.SetTrigger("death");
        currentHealth += heal;
        //Instantiate(HealEffect, SpellPosition.transform.position, Quaternion.identity);
    }

    void Die()
    {
        Destroy(gameObject); Instantiate(ragdoll, transform.position, transform.rotation);

        Debug.Log("ragdoll");
    }
    public void HitVFX(Vector3 hitPosition)
    {
        GameObject hit = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        Destroy(hit, 3f);

    }
}