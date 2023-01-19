using UnityEngine;
public class CombatState_archer : State_archer
{
    float gravityValue;
    public Vector3 currentVelocity;
    bool grounded;
    bool sheathWeapon;
    float playerSpeed;
    public bool attack;
    bool _melee;
    bool usingSkill;
    Vector3 cVelocity;
    public bool jumping;

    public CombatState_archer(Character_archer _character, StateMachine_archer _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        sheathWeapon = false;
        input = Vector2.zero;
        currentVelocity = Vector3.zero;
        gravityVelocity.y = 0;
        attack = false;
        velocity = character.playerVelocity;
        playerSpeed = character.playerSpeed;
        grounded = character.controller.isGrounded;
        gravityValue = character.gravityValue;
        jumping = false;

        usingSkill = character.useSkill;
        _melee = false;

    }

    public override void HandleInput()
    {
        base.HandleInput();

        /*if (skillAction.triggered)
        {
            character.useSkill = true;
            useSkill = character.useSkill;
        }*/

        if (drawWeaponAction.triggered)
        {
            sheathWeapon = true;
        }
        if (attackAction.triggered && !usingSkill)
        {
            if(character.meleeAttack)
            {
                _melee = true;
                Debug.Log("melee " + _melee);
            }
            else
            {
                attack = true;
            }
        }

        if (jumpAction.triggered)
        {
            jumping = true;
        }
       
        input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y);

        //if (character.isAimming) { velocity = velocity.x * new Vector3(1.0f, 0, 0).normalized + velocity.z * new Vector3(0, 0, -1.0f).normalized; }
        //else { velocity = velocity.x * new Vector3(1.0f, 0, 0).normalized + velocity.z * new Vector3(0, 0, 1.0f).normalized; }
        velocity = velocity.x * new Vector3(1.0f, 0, 0).normalized + velocity.z * new Vector3(0, 0, 1.0f).normalized;
        velocity.y = 0f;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        character.isSprinting = true;
        usingSkill = character.useSkill;

        //Debug.Log("Input.x = " + input.x + "Input.y = " + input.y);
        if (character.isAimming)
        {
            if(input.x != 0) { character.animator.SetFloat("horizontal", input.x, character.speedDampTime, Time.deltaTime); }
            else if (input.y != 0) { character.animator.SetFloat("vertical", input.y, character.speedDampTime, Time.deltaTime); }
            
        }
        else
        {
            character.animator.SetFloat("vertical", input.magnitude, character.speedDampTime, Time.deltaTime);
        }

        if (sheathWeapon)
        {
            character.animator.SetTrigger("sheathWeapon");
            stateMachine.ChangeState(character.standing);
        }

        if (attack)
        {
            character.animator.SetTrigger("attack");
            stateMachine.ChangeState(character.attacking);
        }

        if(_melee)
        {
            Debug.Log("melee"+_melee);
            character.animator.SetTrigger("melee");
            _melee = false;
            //stateMachine.ChangeState(character.attacking);
        }
        else if(!_melee)
        {
            character.animator.SetTrigger("move");
        }

        if (jumping)
        {
            character.animator.SetTrigger("jump");
            stateMachine.ChangeState(character.jumping);
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

        character.isSprinting = false;
        gravityVelocity.y = 0f;
        character.playerVelocity = new Vector3(input.x, 0, input.y);

        if (velocity.sqrMagnitude > 0)
        {
            character.transform.rotation = Quaternion.LookRotation(velocity);
        }

    }

}