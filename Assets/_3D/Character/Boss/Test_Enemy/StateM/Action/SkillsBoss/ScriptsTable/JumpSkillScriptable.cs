using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Skills/JumpSkill")]
public class JumpSkillScriptable : ScriptableObject
{
    //public SkillSctiObjectable Jumpingskill;
    public float MinJumpDistance = 1.5f;
    public float MaxJumpDistance = 5f;
    public AnimationCurve HeightCurve;
    public float JumpSpeed = 1;
    public float Cooldown = 10f;
    public float Damage = 10;
    public int Unlocklevel = 1;
    public bool IsActiveing;


    public bool Jump(EnemyBoss Enemy, FieldOfView_Boss fov, bool activeSkill)
    {
        Vector3 startingPos = Enemy.transform.position;

        //Enemy.StartCoroutine(UsingSkill());

        if (NavMesh.SamplePosition(fov.visibleTarget.position, out NavMeshHit hit, 1f, Enemy.agent.areaMask))
        {
            Enemy.agent.Warp(hit.position);
        }

        IEnumerator UsingSkill()
        {
            Vector3 startingPos = Enemy.transform.position;

            //Enemy.animate.animator.SetTrigger("JumpAttackSkill");

            for (float time = 0; time < 1; time += Time.deltaTime * JumpSpeed)
            {
                Enemy.transform.position = Vector3.Lerp(startingPos, fov.visibleTarget.position, time) + (Vector3.up * HeightCurve.Evaluate(time));
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, Quaternion.LookRotation(fov.visibleTarget.position - Enemy.transform.position), time);

                yield return null;
            }
            //_enemy.animate.animator.SetTrigger("move");
            if (NavMesh.SamplePosition(fov.visibleTarget.position, out NavMeshHit hit, 1f, Enemy.agent.areaMask))
            {
                Enemy.agent.Warp(hit.position);
            }
           
            //Enemy.animate.animator.SetTrigger("move");
            activeSkill = false;
        }


        Debug.Log("IsActiving : " + activeSkill);
        return activeSkill;
    }

        
}
