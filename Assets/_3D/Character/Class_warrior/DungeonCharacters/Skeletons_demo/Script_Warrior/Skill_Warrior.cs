using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Skill_Warrior : MonoBehaviour
{

    private string MouseInput;
    public string[] MouseCombo = new string[0];

    private string[] LLL = new string[3] { "L", "L", "L" };
    private string[] LLR = new string[3] { "L", "L", "R" };
    private string[] LRR = new string[3] { "L", "R", "R" };
    private string[] RRR = new string[3] { "R", "R", "R" };
    private string[] RLL = new string[3] { "R", "L", "L" };
    private string[] RRL = new string[3] { "R", "R", "L" };
    private string[] LRL = new string[3] { "L", "R", "L" };
    private string[] RLR = new string[3] { "R", "L", "R" };


    //[SerializeField] GameObject[] skill;
    [SerializeField] CharacterList _character;

    
    public GameObject SpellPosition;
    private Animator anim;
    public bool usingSkill;

    //private int intelligence = 4;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        usingSkill = true;
    }

    // Update is called once per frame
    void Update()
    {
        usingSkill = true;
        ShortKey();
        //MouseInput = Random.Range(1, 3);

        if (Input.GetMouseButtonDown(0))
        {
            
            Debug.Log("Mouse1");
            
            MouseInput = "L";
            MouseCombo = MouseCombo.Append(MouseInput).ToArray();
            //MouseCombo = new string[1] { MouseInput };
            Debug.Log("Clicked " + MouseCombo[0] + " Mouse");
            
            //Click();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse2");
            MouseInput = "R";
            MouseCombo = MouseCombo.Append(MouseInput).ToArray();
            //MouseCombo = new string[1] { MouseInput };
            Debug.Log("Clicked " + MouseCombo[0] + " Mouse");
            //Click();
        }

        if (MouseCombo.Length == 3) /*Input.GetKeyDown("m")*/
        {
            if (MouseCombo.SequenceEqual(LRL))
            {
                anim.SetBool("skill1", true);
                //MouseCombo = new string[0];
            }

            else if (MouseCombo.SequenceEqual(RLR))
            {
                anim.SetBool("skill2", true);
                //MouseCombo = new string[0];
            }
        }
        else
        {
            MouseCombo = new string[0];
        }
        

    }

    public void Check()
    {
        
        Instantiate(_character.skills[1], SpellPosition.transform.position  + SpellPosition.transform.forward, SpellPosition.transform.rotation);

        //Debug.Log(SpellPosition.transform.rotation);
        MouseCombo = new string[0];
        anim.SetBool("skill1", false);
        //gameObject.GetComponent<erika_attack>().enabled = true;
        StartCoroutine(skillstop());
    }

    public void Check2()
    {
        
       
        Instantiate(_character.skills[2], SpellPosition.transform.position + SpellPosition.transform.forward, SpellPosition.transform.rotation);
        MouseCombo = new string[0];
        anim.SetBool("skill2", false);
        StartCoroutine(skillstop());
        //gameObject.GetComponent<erika_attack>().enabled = true;
    }

    IEnumerator skillstop()
    {
        yield return null;//new WaitForSeconds(1.5f);
        usingSkill = false;
        gameObject.GetComponent<Skill_archer>().enabled = false;
        
    }

    private void ShortKey()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetBool("skill1", true);
            MouseCombo = new string[0];
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetBool("skill2", true);
            MouseCombo = new string[0];
        }
    }
}
