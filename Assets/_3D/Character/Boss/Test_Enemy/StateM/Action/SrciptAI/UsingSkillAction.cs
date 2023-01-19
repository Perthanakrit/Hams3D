using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/UsingSkillAction")]
public class UsingSkillAction : Action
{
    public override void Act(SstateController controller)
    {
        Ability(controller);
    }

    private void Ability(SstateController controller)
    {

        FieldOfView_Boss fov = controller.GetComponent<FieldOfView_Boss>();
        if (fov == null) return;
        
        if ((fov.visibleTarget != null && fov.visibleTarget.GetComponent<HealthSystem>()) && controller._combat.abllity.jumpattack.IsActiveing)
        {
            //Debug.Log("JumpSkill!");
            controller._combat.healthSystemPlayer(controller.target.GetComponent<HealthSystem>());
            controller._combat.abllity.jumpattack.IsActiveing = controller._combat.abllity.jumpattack.Jump(
                controller.enemy, fov, controller._combat.abllity.jumpattack.IsActiveing);
        }
    }
}
