using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/State")]
public class StateAI : ScriptableObject
{
    public Action[] actions;
    public TransitionState[] transitions;

    public Color qizmoColor = Color.blue;

    public void UpdateState(SstateController controller)
    {
        ExecuteAction(controller);
        CheckForTransitions(controller);
    }

    private void ExecuteAction(SstateController controller)
    {
        foreach(var action in actions)
        {
            action.Act(controller);
        }
    }

    private void CheckForTransitions(SstateController controller)
    {
        foreach(var transition in transitions)
        {
            bool decision = transition.decision.Decide(controller);
            if (decision)
            {
                controller.TransitionToState(transition.trueState);
            }
            else
            {
                controller.TransitionToState(transition.falseState);
            }
        }
    }
} 
