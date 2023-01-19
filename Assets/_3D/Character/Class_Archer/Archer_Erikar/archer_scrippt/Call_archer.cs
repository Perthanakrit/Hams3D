using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call_archer : MonoBehaviour
{
    [SerializeField] private Character_archer _ch;
    public bool usingSkill;
    private Aim_archer aim;
    void Start()
    {
        aim = GetComponent<Aim_archer>();
        aim.enabled = false;
        usingSkill = false;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            //_ch.useSkill = true;
            usingSkill = true;
            gameObject.GetComponent<Skill_archer>().enabled = true;
            //gameObject.GetComponent<erika_attack>().enabled = false;
            //Debug.Log("Active Array Script");
        }
        /*if (Input.GetKey(KeyCode.LeftControl))
        {
            aim.enabled = !aim.enabled;
            Debug.Log("Active Aim Script");

        }*/
        
    }
    
}
