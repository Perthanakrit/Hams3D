using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Skill : MonoBehaviour
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
    

    //private int intelligence = 4;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //MouseInput = Random.Range(1, 3);

        if (Input.GetMouseButtonDown(0))
        {
            
            Debug.Log("Mouse1");
            /*MouseCombo.Append("L").ToArray();
            foreach (var item in MouseCombo)
            {
                Debug.Log(item);
            }*/
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

        if (MouseCombo.Length == 3/*Input.GetKeyDown("m")*/)
        {
            if((MouseCombo.SequenceEqual(LRL)))
            {
                anim.SetBool("skill1", true);
            }
            
            else if(MouseCombo.SequenceEqual(RLR))
            {
                anim.SetBool("skill2", true);
            }

            Debug.Log("Call Check()");

        }
        

    }

    public void Check()
    {
        //anim = GetComponent<Animator>();

        Debug.Log("Check has been called");     
        Debug.Log("Skill-1 LRL");

        //skill[0].SetActive(true);
        MouseCombo = new string[0];
        //InstantiateParticle(0);
        Instantiate(_character.skills[1], SpellPosition.transform.position  + SpellPosition.transform.forward, SpellPosition.transform.rotation);
            
        //anim.SetBool("hit1", true);
        Debug.Log(SpellPosition.transform.rotation);
            
        
        
        //Debug.Log("Other-Skill");
        //anim.SetBool("skill1", false);
        //skill[0].SetActive(false);
        MouseCombo = new string[0];
                      
        Debug.Log("Disable Array Script");
        anim.SetBool("skill1", false);
        gameObject.GetComponent<erika_Combat>().enabled = true;
        gameObject.GetComponent<Skill>().enabled = false;
    }

    public void Check2()
    {
        
        Debug.Log("Skill-1 LRL");
        //skill[0].SetActive(true);
        MouseCombo = new string[0];
        //InstantiateParticle(0);
        Instantiate(_character.skills[2], SpellPosition.transform.position + SpellPosition.transform.forward, SpellPosition.transform.rotation);

        //anim.SetBool("hit1", true);
        Debug.Log(SpellPosition.transform.rotation);

        
        
        //Debug.Log("Other-Skill");
        //anim.SetBool("skill1", false);
        //skill[0].SetActive(false);
        MouseCombo = new string[0];
        
        
        anim.SetBool("skill2", false);
        gameObject.GetComponent<Skill>().enabled = false;
        gameObject.GetComponent<erika_Combat>().enabled = true;
    }

}
