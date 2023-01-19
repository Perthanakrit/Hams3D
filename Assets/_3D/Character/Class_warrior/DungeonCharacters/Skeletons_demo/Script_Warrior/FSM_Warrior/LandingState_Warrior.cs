using UnityEngine;

public class LandingState_Warrior : State_Warrior
{
    float timePassed;
    float landingTime;

    public LandingState_Warrior(Character_Warrior _character, StateMachine_Warrior _stateMachine) : base(_character, _stateMachine)
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

