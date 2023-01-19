using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class erika_Combat : MonoBehaviour
{
    public static erika_Combat Instance { get; private set; }
    #region Editor Settings
    #endregion
    #region Private Fields
    [SerializeField] private LayerMask groudMask;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform prefabSpawn;
    [SerializeField] private Transform characterTransform;
    //PlayerControls _player;
    private CharacterController _playerControl;
    private Camera mainCamera;
    //[SerializeField] private float shootForce;
    [SerializeField] private float fireCountdown = 0f;
    private float hSliderValue = 0.1f;
    [SerializeField] private Character_archer _ch;
    private bool skillnow;
    private bool cancelAnim;
    [SerializeField] private float attackRange;
    float timePassed;
    private int idObj;
    #endregion
    public CharacterList callskill;
    [HideInInspector] public Character_archer character;
   
    [HideInInspector] public bool isSpecial;
    [HideInInspector] public float coolDown;
    [HideInInspector] public bool isActiveAblilty;

    #region MeleeAttack
    public GameObject[] enemys;
    public bool melee;
    private float distance;
    private float distanceCheck;
    //public float speed = 5f;

    float _distance = Mathf.Infinity;
    #endregion

    public void OnSpecialAttack(InputValue value)
    {
        isSpecial = value.isPressed;
    }


    void Start()
    {
        Instance = this;
        character = GetComponent<Character_archer>();
        mainCamera = Camera.main;
        _playerControl = GetComponent<CharacterController>();
        cancelAnim = false;
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        melee = false;
        distanceCheck = Mathf.Infinity;
        //cooldown
        coolDown = 0;
        /*for (int ab = 0; ab < callskill.skills.Length; ab++)
        {
            StartCoroutine(callskill.skills[ab].CooldownAbility(coolDown));
        }*/
    }
    
    void Update()
    {
        //Shoot();
        SpecialAttack();
        if (enemys.Length != 0)
        {
            MeleeAttack();
        }
       
    }


    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, prefabSpawn.position, transform.rotation);
        projectile.transform.forward = characterTransform.forward;

    }
    public void ShootPassive()
    {
        GameObject projectile = Instantiate(callskill.skills[0].skill, prefabSpawn.position, transform.rotation);
        projectile.transform.forward = characterTransform.forward;
    }

    public GameObject FindClosestEnemy(float distance)
    {
        GameObject closest = null;
        Vector3 position = transform.position;

        foreach (GameObject go in enemys)
        {
            if (go == null)
            {
                return null;
            }
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void WhichEnemyDead(float enemydead)
    {
        for (int e = 0; e < enemys.Length; e++)
        {
            idObj = enemys[e].GetInstanceID();
            if (idObj == enemydead)
            { 
                RemoveElement(ref enemys, e);
            }
        }

    }
    void RemoveElement<T>(ref T[] arr, int index)
    {
        for (int i = index; i < arr.Length - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        Array.Resize(ref arr, arr.Length - 1);
    }

    private void SpecialAttack()
    {
        if (!_ch.useSkill)
        {

            if (character.controller.isGrounded && isSpecial)
            {
                cancelAnim = false;
                character.animator.SetBool("cancel", cancelAnim);
                character.animator.SetBool("aim", isSpecial);

                fireCountdown += hSliderValue;

            }
            else if (!isSpecial)
            {

                if (fireCountdown > 5f)
                {
                    character.animator.SetBool("aim", isSpecial);
                    fireCountdown = 0;
                }
                else
                {
                    cancelAnim = true;
                    character.animator.SetBool("cancel", cancelAnim);
                }

                fireCountdown = 0;

            }
        }
    }

    private void MeleeAttack()
    {

        if (Vector3.Distance(FindClosestEnemy(distanceCheck).transform.position, this.transform.position) <= attackRange)
        {
            melee = true;
            //Debug.Log("MeLee: " + melee);
        }
        else
        {
            melee = false;
        }

    }

    public bool ActivateAbility(int num)
    {
        if (callskill.skills[num].canActivate)
        {
            return callskill.skills[num].canActivate;
        }
        else
        {
            return false;
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }*/

}
