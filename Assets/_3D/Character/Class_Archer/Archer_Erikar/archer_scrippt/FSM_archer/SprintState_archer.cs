using UnityEngine;
public class SprintState_archer : State_archer
{
    float gravityValue;
    Vector3 currentVelocity;

    bool grounded;
    bool sprint;
    float playerSpeed;
    bool sprintJump;
    Vector3 cVelocity;
    public SprintState_archer(Character_archer _character, StateMachine_archer _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        sprint = false;
        sprintJump = false;
        input = Vector2.zero;
        velocity = Vector3.zero;
        currentVelocity = Vector3.zero;
        gravityVelocity.y = 0;

        playerSpeed = character.sprintSpeed;
        grounded = character.controller.isGrounded;
        gravityValue = character.gravityValue;        
    }

    public override void HandleInput()
    {
        base.Enter();
        input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y);

        velocity = velocity.x * new Vector3(1.0f, 0, 0).normalized + velocity.z * new Vector3(0, 0, 1.0f).normalized;
        velocity.y = 0f;
        if (sprintAction.triggered || input.sqrMagnitude == 0f)
        {
            sprint = false;
            character.isSprinting = sprint;
        }
        else
        {
            sprint = true;
            character.isSprinting = sprint;
        }
		if (jumpAction.triggered)
		{
            sprintJump = true;
        }

    }

    public override void LogicUpdate()
    {
        if (sprint)
        {
            //character.animator.SetFloat("horizontal", input.x + 0.5f, character.speedDampTime, Time.deltaTime);
            character.animator.SetFloat("vertical", input.magnitude + 0.5f, character.speedDampTime, Time.deltaTime);
        }
		else
		{
            stateMachine.ChangeState(character.standing);
        }
		if (sprintJump)
		{
            stateMachine.ChangeState(character.sprintjumping);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        gravityVelocity.y += gravityValue * Time.deltaTime;
        grounded = character.controller.isGrounded;
        if (grounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = 0f;
        }
        currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, character.velocityDampTime);

        character.controller.Move(currentVelocity * Time.deltaTime * playerSpeed + gravityVelocity * Time.deltaTime);


        if (velocity.sqrMagnitude > 0)
        {
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(velocity), character.rotationDampTime);
        }
    }
}
