using UnityEngine;

public class LandingState_archer : State_archer
{
    CombatState_archer combatState;
    float timePassed;
    float landingTime;

    public LandingState_archer(Character_archer _character, StateMachine_archer _stateMachine) : base(_character, _stateMachine)
	{
		character = _character;
		stateMachine = _stateMachine;
	}

    public override void Enter()
	{
		base.Enter();
        timePassed = 0f;
        character.animator.SetTrigger("land");
        landingTime = 0.5f;
        combatState.jumping = false;
    }

    public override void LogicUpdate()
    {
        
        base.LogicUpdate();
		if (timePassed> landingTime)
		{
            character.animator.SetTrigger("move");
            stateMachine.ChangeState(character.standing);
        }
        timePassed += Time.deltaTime;
    }



}

