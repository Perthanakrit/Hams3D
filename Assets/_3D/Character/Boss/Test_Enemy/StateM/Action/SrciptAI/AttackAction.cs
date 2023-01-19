using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(SstateController controller)
    {
        Attack(controller);
    }

    private void Attack(SstateController controller)
    {
        FieldOfView_Boss fov = controller.GetComponent<FieldOfView_Boss>();
        if (fov == null) return;

        if (!controller.stateBoolVariable)
        {
            controller.stateTimeElapsed = controller.enemyStats.attackRate;
            controller.stateBoolVariable = true;
        }

        controller._combat.CheckingRange();

        if (fov.visibleTarget != null && fov.visibleTarget.GetComponent <HealthSystem>())
        {
            if(controller._combat.currentCombatState == Combat.combatState.NormalAttack)
            {
                if (controller.HasTimeElapsed(controller.enemyStats.attackRate))
                {
                    //Debug.Log("Attack!");
                    //controller.Com.ShootPlayer(contorller.enemyStats.damage, controller.target.GetComponent<HealthSystem>();)
                    controller._combat.healthSystemPlayer(controller.target.GetComponent<HealthSystem>());
                    controller.characterAnim.AnimateAttack();
                    //controller._combat.pauseT = 10.0f;
                    //controller.attacking = true;
                    controller.agent.isStopped = false;

                }
            }
            else if (controller._combat.currentCombatState == Combat.combatState.JumpSkill)
            {
                if (controller.HasTimeElapsed(controller._combat.abllity.jumpattack.Cooldown) && controller.agent.velocity.y == 0)
                {
                    //controller._combat.abllity.jumpattack.IsActiveing = false;
                    controller._combat.healthSystemPlayer(controller.target.GetComponent<HealthSystem>());
                    controller.characterAnim.AnimateJumpSkill();
                    controller.rb.AddForce(Vector3.up * 150f, ForceMode.Force);
                }
            }
        }

        //controller.characterAnim.animator.SetTrigger("JumpAttackSkill");
    }
}
