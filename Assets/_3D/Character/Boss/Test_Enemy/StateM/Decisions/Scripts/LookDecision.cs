using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="AI/Decision/Look")]
public class LookDecision : Decision
{
    public override bool Decide(SstateController controller)
    {
        return Look(controller);
    }

    private bool Look(SstateController controller)
    {

        FieldOfView_Boss fov  = controller.GetComponent <FieldOfView_Boss>();
        if (fov == null) return false;
            
        if(fov.visibleTarget != null && fov.visibleTarget.GetComponent<HealthSystem>() != null)
        {
            controller.target = fov.visibleTarget;
            //Debug.Log("I got u.");
            return true;
        }
        return false;
    }
}
