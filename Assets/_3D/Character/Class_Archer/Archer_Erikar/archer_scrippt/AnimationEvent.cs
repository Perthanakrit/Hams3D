using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] private DamageDealerErikaArcher damage;
    [SerializeField] private Aim_archer aim;
    [SerializeField] private Character_archer character;
    //[SerializeField] private Skill_archer ability;
    public void StartDealDamageErika()
    {
        Debug.Log("Damage TRUE");
        damage.canDealDamage = true;
        damage.hasDealtDamage.Clear();
    }
    public void EndDealDamageErika()
    {
        Debug.Log("Damage FALSE");
        damage.canDealDamage = false;
    }

    public void isAimminmg()
    {
        bool mouseClick = character.combatting.attack;
        aim.enabled = true;
        Debug.Log("mouseClick -" + mouseClick);
        aim.isAttacking = mouseClick;
    }
    public void CancelAimming()
    {   
        aim.isAttacking = false;
        aim.enabled = false;
    }

    public void isActivatingSkill()
    {
        //if(ability.isActivatingSkill) character.isSpelling = true;
    }
    public void EndActivateSkill()
    {
        character.enabled = true;
        //character.isSpelling = false;
    }
    public void ActivatedSkill2()
    {
        character.enabled = true;
        //character.isSpelling = false;
    }
}
