using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cooldowns_Per;

[System.Serializable]
public class UICharacters
{
    public Character_archer archer;
    public Character_Warrior warrior;
}



public class UI_Character : MonoBehaviour
{
    #region Variable Inspector
    [Header("Refernce")]
    //[SerializeField] private erika_Combat character;
    private cooldowMutiSkills coolDownSys;
    
    private GameObject player;
    private float coolDown;
    private float id;
    private bool canActivateSkill;

    [Header("UI")]
    [SerializeField] private Image[] skillsUI;
    private float constactV = 0.175f;
    
    #endregion
 
    [HideInInspector] public float amoutimageUI;
    //public List<float> fillamouts;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coolDownSys = player.GetComponent<cooldowMutiSkills>();

        for(int im=0; im < coolDownSys.abilities.Count; im++)
        {
            skillsUI[im].sprite = coolDownSys.abilities[im].image;
            //character.callskill.skills[u].countDown = 0.0f;
            skillsUI[im].fillAmount = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {   //  x2 = CoolDown - RemainingTime
        // fillAmout = x2/100 +(1f * Time.detatime)
        for (int ab = 0; ab < coolDownSys.abilities.Count; ab++)
        {
            //Debug.Log("fillAmount" + coolDownSys.abilities[ab].Id + " | " + useNextTime);
            if (!coolDownSys.abilities[ab].canActivate)
            {
                float useNextTime = coolDownSys.abilities[ab].fakeTime / coolDownSys.abilities[ab].cooldown;
                skillsUI[ab].fillAmount = useNextTime;
            }          
        }

    }

    /*void UseSkill()
    {
        for (int ab = 1; ab < character.callskill.skills.Length; ab++)
        {
            if (!character.callskill.skills[ab].canActivate)
            {
                skillsUI[ab - 1].fillAmount = fillamouts[ab - 1] / character.callskill.skills[ab].cooldown;
                fillamouts[ab - 1] += (1f * Time.deltaTime);
                if (amoutimageUI >= character.callskill.skills[ab].cooldown) skillsUI[ab - 1].fillAmount = 1;
            }
            else { skillsUI[ab - 1].fillAmount = 1; }
        }
    }*/
}
