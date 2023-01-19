using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(SstateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(SstateController controller)
    {
        EnemyBoss enemy = controller.GetComponent<EnemyBoss>();
        enemy.currentState = CurrentState.Partrol;
        controller.agent.speed = controller.enemyStats.walkSpeed;

        controller.agent.destination = controller.waypoint[controller.nextWayPoint].position;
        controller.agent.Resume();
        if(controller.agent.remainingDistance <= controller.agent.stoppingDistance && !controller.agent.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.waypoint.Count;
            Debug.Log("Waypoint");
        }
        
    }
}
