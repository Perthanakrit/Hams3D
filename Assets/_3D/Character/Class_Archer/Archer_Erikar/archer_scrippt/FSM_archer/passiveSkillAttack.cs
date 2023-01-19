using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passiveSkillAttack : State_archer
{
    float timePassed;
    float clipLength;
    float clipSpeed;
    bool attack;
    bool isPassive;
    public passiveSkillAttack(Character_archer _character, StateMachine_archer _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        isPassive = false;
        character.animator.applyRootMotion = true;
        timePassed = 0f;
        character.animator.SetBool("aim",false);
        character.animator.SetFloat("speed", 0f);
        character.animator.SetFloat("vertical", 0f);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timePassed += Time.deltaTime;
        clipLength = character.animator.GetCurrentAnimatorClipInfo(1)[0].clip.length;
        clipSpeed = character.animator.GetCurrentAnimatorStateInfo(1).speed;

        if (timePassed >= clipLength / clipSpeed && attack)
        {
            stateMachine.ChangeState(character.passiveAttacking);
        }
        if (timePassed >= clipLength / clipSpeed)
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