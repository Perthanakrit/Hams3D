using UnityEngine;
public class AttackState_archer : State_archer
{
    //CombatState_archer combat;
    float timePassed;
    float clipLength;
    float clipSpeed;
    public bool attack;
    bool usingSkill;
    bool _melee;
    public AttackState_archer(Character_archer _character, StateMachine_archer _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        attack = false;
        character.animator.applyRootMotion = true;
        timePassed = 0f;
        character.animator.SetTrigger("attack"); 
        character.animator.SetFloat("speed", 0f);
        character.animator.SetFloat("vertical", 0f);

        //character._skill.usingSkill = false;
        usingSkill = character.useSkill;
        _melee = false;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if (attackAction.triggered && !usingSkill)
        {

            if (character.meleeAttack)
            {
                _melee = true;
                Debug.Log("melee " + _melee);
            }
            else
            {
                attack = true; 
                Debug.Log("attack_state " + attack);
            }
        }
        
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timePassed += Time.deltaTime;
        clipLength = character.animator.GetCurrentAnimatorClipInfo(1)[0].clip.length;
        clipSpeed = character.animator.GetCurrentAnimatorStateInfo(1).speed;

        if (timePassed >= clipLength / clipSpeed && (attack||_melee))
        {
            stateMachine.ChangeState(character.attacking);
        }
        if (timePassed >= clipLength / clipSpeed && !usingSkill)
        {
            stateMachine.ChangeState(character.combatting);
            character.animator.SetTrigger("move");
        }

    }
    public override void Exit()
    {
        base.Exit();
        character.animator.applyRootMotion = false;
    }
}