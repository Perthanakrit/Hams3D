using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public enum combatState
    {
        NormalAttack,
        JumpSkill
    }
    #region Private
    private HealthSystem healthPlayer;
    [SerializeField] private GameObject fist;
    [SerializeField] private float attackRange = 1.0f;
    //[SerializeField] private float floatuseJumpSkill;
    #endregion
    [HideInInspector] public SstateController controller;
    [HideInInspector] public Rigidbody rb;
    public float currentdamage;

    [HideInInspector] public float jumpHeight;
    [SerializeField] private ExoplodeForce landing;

    [Header("Skills")]
    public AbllitySys abllity;
    [HideInInspector] public float pauseT;

    [HideInInspector] public combatState currentCombatState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<SstateController>();
        fist.SetActive(true);
        pauseT = 0;
        //fov = controller.GetComponent<FieldOfView>();
    }

    public (bool, string) CheckRange()
    {
        FieldOfView_Boss fov = GetComponent<FieldOfView_Boss>();
        float useJumpSkill = fov.viewRadius;
        if (Vector3.Distance(fov.visibleTarget.position, transform.position) <= attackRange)
        {
            controller.agent.isStopped = true;
            currentCombatState = combatState.NormalAttack;
            return (true, "NormalAttack");
        }
        else if (Vector3.Distance(fov.visibleTarget.position, transform.position + new Vector3(0,0,attackRange)) <= useJumpSkill - attackRange)
        {
            currentCombatState = combatState.JumpSkill;
            return (true, "JumpSkill");
        }
        else
        {
            return (false, null);
        }
    }

    public void CheckingRange()
    {
        FieldOfView_Boss fov = GetComponent<FieldOfView_Boss>();
        float useJumpSkill = fov.viewRadius;
        if (fov.visibleTarget == null) return;
        if (Vector3.Distance(fov.visibleTarget.position, transform.position) <= attackRange)
        {
            controller.agent.isStopped = true;
            currentCombatState = combatState.NormalAttack;
           
        }
        else if (Vector3.Distance(fov.visibleTarget.position, transform.position + new Vector3(0, 0, attackRange)) <= useJumpSkill - attackRange)
        {
            currentCombatState = combatState.JumpSkill;
  
        }
    }

    public float NormalDamage()
    {
        currentdamage = controller.enemyStats.damage;
        //Debug.Log(currentdamage);
        return currentdamage;
    }
    public void BossStartDealDamage()
    {
        //GetComponentInChildren<EnemyDamageDealer>().EnemyStartDealDamage();
    }

    public void BossEndDealDamage()
    {
        //GetComponentInChildren<EnemyDamageDealer>().EnemyEndDealDamage();
    }

    public void healthSystemPlayer(HealthSystem health)
    {
        //health.TakeDamage(damage);
        //Debug.Log("healthSYS");
        healthPlayer = health;
    }

   

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
