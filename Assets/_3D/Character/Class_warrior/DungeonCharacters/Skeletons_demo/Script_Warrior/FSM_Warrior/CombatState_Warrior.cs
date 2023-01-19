using UnityEngine;
public class CombatState_Warrior : State_Warrior
{
    float gravityValue;
    Vector3 currentVelocity;
    bool grounded;
    bool sheathWeapon;
    float playerSpeed;
    bool attack;
    //bool cskill;
    bool Wskill;

    Vector3 cVelocity;

    public CombatState_Warrior(Character_Warrior _character, StateMachine_Warrior _stateMachine) : base(_character, _stateMachine)
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
        //cskill = false;
        Wskill = character.Wisuseskill;

        velocity = character.playerVelocity;
        playerSpeed = character.playerSpeed;
        grounded = character.controller.isGrounded;
        gravityValue = character.gravityValue;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (drawWeaponAction.triggered)
        {
            sheathWeapon = true;
        }

        if (attackAction.triggered && !Wskill)
        {
            //cskill = false;
            attack = true;
        }

        /*if (castskillAction.triggered)
        {
            attack = false;
            //cskill = true;
        }*/

        input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y);

        velocity = velocity.x * new Vector3(1.0f, 0f, 0f).normalized + velocity.z * new Vector3(0f, 0f, 1.0f).normalized;
        velocity.y = 0f;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Wskill = character.Wisuseskill;

        character.animator.SetFloat("speed", input.magnitude, character.speedDampTime, Time.deltaTime);

        if (character.animator.GetFloat("speed") <= 0.1)
        {
            character.animator.applyRootMotion = true;
        }
        
        if (character.animator.GetFloat("speed") >= 0.1)
        {
            character.animator.applyRootMotion = false;
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

        /*f (cskill)
        {
            character.animator.SetTrigger("cast");
            stateMachine.ChangeState(character.castskill);
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

        character.animator.applyRootMotion = false;
        gravityVelocity.y = 0f;
        character.playerVelocity = new Vector3(input.x, 0, input.y);

        if (velocity.sqrMagnitude > 0)
        {
            character.transform.rotation = Quaternion.LookRotation(velocity);
        }

    }

}