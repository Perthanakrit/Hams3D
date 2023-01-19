using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(SstateController controller)
    {
        Chase(controller);
    }

    private void Chase(SstateController controller)
    {
        EnemyBoss enemy = controller.GetComponent<EnemyBoss>();
        enemy.currentState = CurrentState.Attack;
        controller.agent.speed = controller.enemyStats.runSpeed;
        controller.speedBeforeAttacking = controller.agent.velocity;
        FieldOfView_Boss fov = controller.GetComponent<FieldOfView_Boss>();

        if (fov == null) return;
        if(fov.visibleTarget != null)
        {
            //Debug.Log("pauseTime "+ controller._combat.pauseT);

            //controller.enemy.StartCoroutine(pauseMove());
            controller.agent.destination = controller.target.position;
            controller.lastKwonTargetPostion = controller.target.position;
            controller.agent.Resume(); //Resumes(V.) the movement along the current path after a pause.
        }
        else
        {
            controller.agent.destination = controller.lastKwonTargetPostion;
            controller.agent.Resume();
        }

        IEnumerator pauseMove()
        {
 
            yield return controller._combat.pauseT;
            controller.agent.destination = controller.target.position;
            controller.lastKwonTargetPostion = controller.target.position;
        }
    }
   
}
