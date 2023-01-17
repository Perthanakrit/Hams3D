using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

namespace Cooldowns_Per
{
    [CreateAssetMenu(menuName = "Character/cooldonwSystem")]
    public class CooldownSystem_Per : ScriptableObject
    {
        public List<CooldownData> cooldowns = new List<CooldownData>();
        [SerializeField] private CharacterList abilities;
        //void Update() => ProcessCooldowns();

        public void PutOnCooldown(IHasCooldown cooldown)
        {
            cooldowns.Add(new CooldownData(cooldown));
          
        }
        public bool IsOnCooldown(int id)
        {
            foreach (CooldownData cooldown in cooldowns)
            {
                if (cooldown.Id == id) { return true; }
            }

            return false;
        }

        /*public float GetRemainingDuration(int id)
        {
            foreach (CooldownData cooldown in cooldowns)
            {
                if (cooldown.Id != id) { continue; }

                return cooldown.RemainingTime;
            }

            return 0f;
        }*/
        public void ProcessCooldowns()
        {
            float deltaTime = Time.deltaTime;

            for (int i = cooldowns.Count - 1; i >= 0; i--)
            {
                if (cooldowns[i].DecrementCooldown(deltaTime) && abilities.skills[i].canActivate)
                {
                    cooldowns.RemoveAt(i);
                    Debug.Log(cooldowns.Count);
                }
            }
        }
    }

    public class CooldownData
    {
        public CooldownData(IHasCooldown cooldown)
        {
            Id = cooldown.Id;
            RemainingTime = cooldown.CooldownDuration;
        }

        public int Id { get; }
        public float RemainingTime { get; private set; }
        public float filledUI;

        public bool DecrementCooldown(float deltatime)
        {
            RemainingTime = Mathf.Max(RemainingTime - deltatime, 0);
            //Debug.Log(RemainingTime);
            return RemainingTime == 0f;
        }
        public float amountFillUI(float cooldown)
        {
            filledUI = (cooldown - RemainingTime)/100;
            return filledUI;
        }
    }
}