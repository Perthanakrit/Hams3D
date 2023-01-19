using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState_archer : State_archer
{
    float timePassed;
    float clipLength;
    float clipSpeed;
    bool usingSkill;
    public SkillState_archer(Character_archer _character, StateMachine_archer _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

       
        //character.animator.applyRootMotion = true;
        timePassed = 0f;
       
        character.animator.SetFloat("speed", 0f);
        character.animator.SetFloat("vertical", 0f);

        usingSkill = character.useSkill;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (skillAction.triggered)
        {
            usingSkill = true;
        }
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timePassed += Time.deltaTime;
        clipLength = character.animator.GetCurrentAnimatorClipInfo(1)[0].clip.length;
        clipSpeed = character.animator.GetCurrentAnimatorStateInfo(1).speed;

        if (timePassed >= clipLength / clipSpeed && usingSkill)
        {
            stateMachine.ChangeState(character.usingskill);
        }
        if (timePassed >= clipLength  / clipSpeed)
        {
            //character._skill.usingSkill = useSkill;
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
