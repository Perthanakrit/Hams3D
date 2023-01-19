using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Skill_archer : MonoBehaviour
{

    private string MouseInput; 
    public string[] MouseCombo = new string[0];
    [HideInInspector] public bool isActivatingSkill;

    #region PattenSkills
    private string[] LLL = new string[3] { "L", "L", "L" };
    private string[] LLR = new string[3] { "L", "L", "R" };
    private string[] LRR = new string[3] { "L", "R", "R" };
    private string[] RRR = new string[3] { "R", "R", "R" };
    private string[] RLL = new string[3] { "R", "L", "L" };
    private string[] RRL = new string[3] { "R", "R", "L" };
    private string[] LRL = new string[3] { "L", "R", "L" };
    private string[] RLR = new string[3] { "R", "L", "R" };
    #endregion

    [SerializeField] CharacterList _character;
    private Rigidbody rb;
    [SerializeField] private float dashForec;
    public GameObject SpellPosition;
    private Animator anim;
    [SerializeField] public Character_archer activeSkill;
    [SerializeField] private Call_archer call;
    private erika_Combat erikaAbility;
    [SerializeField] private ManaSystem manasys;
    private UI_Character _ui;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        erikaAbility = GetComponent<erika_Combat>();
        _ui = GetComponent<UI_Character>();
        //usingSkill = true;
    }

    // Update is called once per frame
    void Update()
    {
        ShortKey();
        if (Input.GetMouseButtonDown(0))
        {
            MouseInput = "L";
            MouseCombo = MouseCombo.Append(MouseInput).ToArray();
           
        }
        if (Input.GetMouseButtonDown(1))
        { 
            MouseInput = "R";
            MouseCombo = MouseCombo.Append(MouseInput).ToArray();       
        }
        if(MouseCombo.Length >= 1)
        {
            StartCoroutine(ResetMouseCombo());
        }

        if (MouseCombo.Length == 3)
        {
            if ((MouseCombo.SequenceEqual(LRL) && erikaAbility.ActivateAbility(1)) && manasys.currentMana >= _character.skills[1].manavalue)
            {
                activeSkill.enabled = false; 
                anim.SetBool("skill1", true); 
            }
            else if (MouseCombo.SequenceEqual(RLR) && erikaAbility.ActivateAbility(2) && manasys.currentMana >= _character.skills[2].manavalue)
            {
                activeSkill.enabled = false;     
                anim.SetBool("skill2", true);
            }
            else if (MouseCombo.SequenceEqual(RRL) && erikaAbility.ActivateAbility(3) && manasys.currentMana >= _character.skills[3].manavalue)
            {
                activeSkill.enabled = false;    
                anim.SetBool("skill3", true);
            }
        }
    }

    public void Check()
    {
        manasys.UseMana(_character.skills[1].manavalue);// Mana cost
        Instantiate(_character.skills[1].skill, SpellPosition.transform.position, SpellPosition.transform.rotation);       
        _character.skills[1].canActivate = false;
        MouseCombo = new string[0];       
        anim.SetBool("skill1", false);
        
        StartCoroutine(skillstop());
    }

    public void Check2()
    {
        manasys.UseMana(_character.skills[2].manavalue);// Mana cost
        Instantiate(_character.skills[2].skill, SpellPosition.transform.position, SpellPosition.transform.rotation);
        _character.skills[2].canActivate = false;
        MouseCombo = new string[0];
        anim.SetBool("skill2", false);
        
        StartCoroutine(skillstop());
    }

    public void ability3()
    {
        manasys.UseMana(_character.skills[3].manavalue);// Mana cost
        Instantiate(_character.skills[3].skill, SpellPosition.transform.position, SpellPosition.transform.rotation);
        rb.AddForce(-transform.forward * dashForec, ForceMode.Impulse);
        _character.skills[3].canActivate = false;
        MouseCombo = new string[0];
        anim.SetBool("skill3", false);
       
        StartCoroutine(skillstop());
    }

    IEnumerator skillstop()
    {
        yield return new WaitForSeconds(0.1f);
        //activeSkill.useSkill = false; 
        call.usingSkill = false;
        gameObject.GetComponent<Skill_archer>().enabled = false;
        
    }
    IEnumerator ResetMouseCombo()
    {
        yield return  new WaitForSeconds(1.1f);
        MouseCombo = new string[0];
    }

    private void ShortKey()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            MouseCombo = new string[3];
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            MouseCombo = new string[3];
        }
    }
}
