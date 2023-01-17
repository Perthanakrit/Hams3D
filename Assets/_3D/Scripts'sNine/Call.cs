using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call : MonoBehaviour
{
    public bool useskill;
    public Character CH;
    public Aim aim;
    public Mage_Skill skill;
    public GameObject hand_trailR;
    public GameObject hand_trailL;

    private void Start()
    {
        useskill = false;
        CH = this.GetComponent<Character>();
        skill = this.GetComponent<Mage_Skill>();
        aim = this.GetComponent<Aim>();
    }

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            skill.enabled = true;
            //this.GetComponent<Warrior_Skill>().enabled = true;
            useskill = true;
            Debug.Log("Active Skill Script");
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            aim.enabled = !aim.enabled;
            Debug.Log("De/Active Aim Script");
        }
        
        if (Input.GetKeyDown("r"))
        {
            hand_trailR.SetActive(!hand_trailR.activeSelf);
            hand_trailL.SetActive(!hand_trailL.activeSelf);
        }
        

    }
}
