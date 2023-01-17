using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Cooldowns_Per
{
    public class TestAbility_Per : MonoBehaviour, IHasCooldown
    {
        [Header("References")]
        public CooldownSystem_Per cooldownSystem;
        private CharacterList abilities;

        [Header("Settings")]
        public int id ;
        public float cooldownDuration;

        public int Id => id;
        public float CooldownDuration => cooldownDuration;

        private void Start()
        {
            abilities = this.GetComponent<erika_Combat>().callskill;
            //ForAbilities();
            for (int abi=1; abi < abilities.skills.Length; abi++)
            {
                abilities.skills[abi].canActivate = true;
                id = abilities.skills[abi].Id; 
                cooldownDuration = abilities.skills[abi].cooldown;
                cooldownSystem.PutOnCooldown(this);
            }
            
        }

        private void Update()
        {
            for (int abi = 1; abi < abilities.skills.Length; abi++)
            {                
                if (!abilities.skills[abi].canActivate)
                {
                    id = abilities.skills[abi].Id;
                    cooldownDuration = abilities.skills[abi].cooldown;
                    //Debug.Log("ID = " + id);
                    cooldownSystem.ProcessCooldowns();
                    if (cooldownSystem.IsOnCooldown(Id)) { return; }
                    abilities.skills[abi].canActivate = true;
                    Debug.Log("ID = "+id+" ability.canActivate: " + abilities.skills[abi].canActivate);
                    cooldownSystem.PutOnCooldown(this);
                }
            }
            //Debug.Log("Not Return");
            
        }

    }
}
