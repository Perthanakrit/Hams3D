using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cooldowMutiSkills : MonoBehaviour
{
    public List<skills_Scriptable> abilities = new List<skills_Scriptable>();
    UICharacters UIcharacter;

    void Start()
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            abilities[i].canActivate = true;
            abilities[i].fakeTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i< abilities.Count; i++)
        {
            OnCooldown(abilities[i]);
        }
    }

    void OnCooldown(skills_Scriptable ability)
    {
        if (ability.canActivate) return;
        // function when ablility is unactivated 
        ability.fakeTime += 1 * Time.deltaTime;
        Debug.Log("Ability is cooldown" + ability.Id+" | "+ (ability.cooldown- ability.fakeTime));
        if ((ability.cooldown - ability.fakeTime) <= 0)
        {
            ability.fakeTime = 0;
            ability.canActivate = true;   
        }
            
    }
}

