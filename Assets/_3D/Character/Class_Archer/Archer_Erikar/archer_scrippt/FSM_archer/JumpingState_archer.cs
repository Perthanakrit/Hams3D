using UnityEngine;

public class JumpingState_archer : State_archer
{
    bool grounded;

    float gravityValue;
    float jumpHeight;
    float playerSpeed;

    Vector3 airVelocity;

    public JumpingState_archer(Character_archer _character, StateMachine_archer _stateMachine) : base(_character, _stateMachine)
	{
		character = _character;
		stateMachine = _stateMachine;
	}

    public override void Enter()
	{
		base.Enter();

		grounded = false;
        gravityValue = character.gravityValue;
        jumpHeight = character.jumpHeight;
        playerSpeed = character.playerSpeed;
        gravityVelocity.y = 0;

        //character.animator.SetFloat("vertical", 0);
        character.animator.SetTrigger("jump");
        Debug.Log("Jumping");
        Jump();
	}
	public override void HandleInput()
	{
		base.HandleInput();

        input = moveAction.ReadValue<Vector2>();
    }

	public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (grounded)
		{
            stateMachine.ChangeState(character.landing);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
		if (!grounded)
		{

            velocity = character.playerVelocity;
            airVelocity = new Vector3(input.x, 0, input.y);

            velocity = velocity.x * new Vector3(1.0f, 0, 0).normalized + velocity.z * new Vector3(0, 0, 1f).normalized;
            velocity.y = 0f;
            airVelocity = airVelocity.x * new Vector3(1.0f, 0, 0).normalized + airVelocity.z * new Vector3(0, 0, 1f).normalized;
            airVelocity.y = 0f;
            character.controller.Move(gravityVelocity * Time.deltaTime+ (airVelocity*character.airControl+velocity*(1- character.airControl))*playerSpeed*Time.deltaTime);
        }

        gravityVelocity.y += gravityValue * Time.deltaTime;
        grounded = character.controller.isGrounded;
    }

    void Jump()
    {
        gravityVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }

}

