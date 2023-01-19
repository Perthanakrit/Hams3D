using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/TargetNotVisible")]
public class VisibleTargetDecison : Decision
{
    public override bool Decide(SstateController controller)
    {
        return TargetNotVisible(controller);
    }

    private bool TargetNotVisible(SstateController controller)
    {
        EnemyBoss enemy = controller.GetComponent<EnemyBoss>();
        enemy.currentState = CurrentState.Search;
        //controller.agent. = controller.enemyStats.walkSpeed;

        controller.transform.Rotate(0, (controller.enemyStats.searchTurnSpeed / controller.characterAnim.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length) * Time.deltaTime, 0);

        return controller.HasTimeElapsed(controller.enemyStats.searcherDuration);
    }
}
