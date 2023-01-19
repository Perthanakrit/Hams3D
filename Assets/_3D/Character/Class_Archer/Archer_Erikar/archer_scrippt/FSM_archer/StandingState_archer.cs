using UnityEngine;

public class StandingState_archer : State_archer
{
    bool walk;
    float gravityValue;
    bool jump;
    bool crouch;
    Vector3 currentVelocity;
    bool grounded;
    bool sprint;
    float playerSpeed;
    bool drawWeapon;

    Vector3 cVelocity;

    public StandingState_archer(Character_archer _character, StateMachine_archer _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        walk = false;
        jump = false;
        crouch = false;
        sprint = false;
        drawWeapon = false;
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
        if (moveAction.triggered)
        {
            walk = true;
        }
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

        input = moveAction.ReadValue<Vector2>();
      
        

        velocity = new Vector3(input.x, 0, input.y);

        // Returns this vector with a magnitude of 1 ,  magnitude :  square root of x^2+y^2+z^2 or ขนาดของเวกเตอร์
        //if (character.isAimming) { velocity = velocity.x * new Vector3(1.0f, 0, 0).normalized + velocity.z * new Vector3(0, 0, -1.0f).normalized; }
        //else { velocity = velocity.x * new Vector3(1.0f, 0, 0).normalized + velocity.z * new Vector3(0, 0, 1.0f).normalized; }
        velocity = velocity.x * new Vector3(1.0f, 0, 0).normalized + velocity.z * new Vector3(0, 0, 1.0f).normalized;
        velocity.y = 0f;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //character.animator.SetFloat("horizontal", input.x, character.speedDampTime, Time.deltaTime);
       
        /*if (character.isAimming) 
        {
            if (input.x > 0) { character.animator.SetFloat("vertical", input.magnitude, character.speedDampTime, Time.deltaTime);}
            else if (input.x < 0) { character.animator.SetFloat("vertical", input.x, character.speedDampTime, Time.deltaTime); }
        }
        else*/  
        character.animator.SetFloat("vertical", input.magnitude, character.speedDampTime, Time.deltaTime); 


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