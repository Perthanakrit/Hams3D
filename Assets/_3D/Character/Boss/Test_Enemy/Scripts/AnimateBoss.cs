using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBoss : MonoBehaviour
{
    public Animator animator;
    private EnemyBoss enemy;
    [SerializeField] private FIstDealDamage daelDamage;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<EnemyBoss>();
    }

    public void AnimateStop()
    {
        animator.SetFloat("vertical", 0);
        animator.SetFloat("horizontal", 0);
    }
    public void AnimateRun(float magnitude, float speed)
    {
        animator.SetFloat("vertical", (magnitude / speed) + 0.5f);
        animator.SetFloat("horizontal", 0);
    }
    public void AnimateWalk(float magnitude, float speed)
    {
        animator.SetFloat("horizontal", 0);
        animator.SetFloat("vertical", magnitude / speed);
    }
    public void AnimateSearch(float trun, float angular)
    {
        animator.SetFloat("horizontal", trun / angular);
        animator.SetFloat("vertical", trun / angular);
    }
    public void AnimateAttack()
    {
        animator.SetTrigger("attack");
        daelDamage.ColliderEnable();
    }

    public void AnimateJumpSkill()
    {
        animator.SetTrigger("JumpAttackSkill");
    }
    public void BossActiveVFXGround()
    {
        enemy.agent.isStopped = true;
        GetComponentInChildren<groundVFX>().ActiveVFXGround();
    }
    public void BossNotActiveVFXGround()
    {
        StartCoroutine(pauseMove());
        //GetComponentInChildren<groundVFX>().NotActive();
    }


    IEnumerator pauseMove()
    {
        yield return new WaitForSeconds(1.5f);
        enemy.agent.isStopped = false;
    }
}
