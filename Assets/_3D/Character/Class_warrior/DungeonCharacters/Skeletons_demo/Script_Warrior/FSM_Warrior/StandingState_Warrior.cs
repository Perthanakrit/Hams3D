using UnityEngine;

public class StandingState_Warrior : State_Warrior
{
    float gravityValue;
    bool jump;
    bool crouch;
    Vector3 currentVelocity;
    bool grounded;
    bool sprint;
    float playerSpeed;
    bool drawWeapon;
    //bool cskill;

    Vector3 cVelocity;

    public StandingState_Warrior(Character_Warrior _character, StateMachine_Warrior _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        jump = false;
        crouch = false;
        sprint = false;
        drawWeapon = false;
        //cskill = false;
        input = Vector2.zero;

        currentVelocity = Vector3.zero;
        gravityVelocity.y = 0;

        velocity = character.playerVelocity;
        playerSpeed = character.playerSpeed;
        grounded = character.controller.isGrounded;
        gravityValue = character.gravityValue;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (jumpAction.triggered)
        {
            jump = true;
        }
        if (crouchAction.triggered)
        {
            crouch = true;
        }
        if (sprintAction.triggered)
        {
            sprint = true;
        }

        if (drawWeaponAction.triggered)
        {
            drawWeapon = true;
        }

        /*if (castskillAction.triggered)
        {
            cskill = true;
        }*/

        input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y);

        velocity = velocity.x * new Vector3(1.0f, 0f, 0f).normalized + velocity.z * new Vector3(0f, 0f, 1.0f).normalized;
        velocity.y = 0f;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        character.animator.SetFloat("speed", input.magnitude, character.speedDampTime, Time.deltaTime);
        //character.animator.SetFloat("Horizontal", input.x, character.speedDampTime, Time.deltaTime);
        //character.animator.SetFloat("Vertical", input.y, character.speedDampTime, Time.deltaTime);

        if (sprint)
        {
            stateMachine.ChangeState(character.sprinting);
        }
        if (jump)
        {
            stateMachine.ChangeState(character.jumping);
        }
        if (crouch)
        {
            stateMachine.ChangeState(character.crouching);
        }
        if (drawWeapon)
        {
            stateMachine.ChangeState(character.combatting);
            character.animator.SetTrigger("drawWeapon");
        }
        /*if (cskill)
        {
            stateMachine.ChangeState(character.castskill);
            character.animator.SetTrigger("cast");
        }*/
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

    public override void Exit()
    {
        base.Exit();

        gravityVelocity.y = 0f;
        character.playerVelocity = new Vector3(input.x, 0, input.y);

        if (velocity.sqrMagnitude > 0)
        {
            character.transform.rotation = Quaternion.LookRotation(velocity);
        }
    }

}