using UnityEngine;
public class SprintJumpState_archer : State_archer
{
    float timePassed;
    float jumpTime;

    public SprintJumpState_archer(Character_archer _character, StateMachine_archer _stateMachine) : base(_character, _stateMachine)
	{
		character = _character;
		stateMachine = _stateMachine;
	}

    public override void Enter()
	{
		base.Enter();
        character.animator.applyRootMotion = true;
        timePassed = 0f;
        character.animator.SetTrigger("sprintJump");

        jumpTime = 1f;
    }

	public override void Exit()
	{
		base.Exit();
        character.animator.applyRootMotion = false;
    }

	public override void LogicUpdate()
    {
        
        base.LogicUpdate();
		if (timePassed> jumpTime)
		{
            character.animator.SetTrigger("move");
            stateMachine.ChangeState(character.sprinting);
        }
        timePassed += Time.deltaTime;
    }



}

