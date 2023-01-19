using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum CurrentState
{
    Partrol,
    Attack,
    Search,
}


public class EnemyBoss : MonoBehaviour
{
    #region Animation
    public AnimateBoss animate;
    [Header("Animation Smoothing")]
    [Range(0, 1)]
    public float speedDampTime = 0.1f;
    [Range(0, 1)]
    public float velocityDampTime = 0.9f;
    [Range(0, 1)]
    public float rotationDampTime = 0.2f;
    [Range(0, 1)]
    public float airControl = 0.5f;
    #endregion
    [Header(" ")]
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Transform _transform;
    public CurrentState currentState;
    [HideInInspector] public Vector2 speedA;
    private SstateController controller;

    Enemy enemyHp;
    [HideInInspector]public float m_Var;
    [HideInInspector]public float last_var;
    

    private void Awake()
    {
        animate = GetComponent<AnimateBoss>();
        agent = GetComponent<NavMeshAgent>();
        controller = GetComponent<SstateController>();
        _transform = this.GetComponent<Transform>();
        enemyHp = GetComponent<Enemy>();
       
    }
    private void Start()
    {
        last_var = enemyHp.currenthealth; 
    }
    private void Update()
    {
        last_var = enemyHp.currenthealth;
        //Debug.Log(agent.velocity);
        if (Mathf.Abs(agent.velocity.x) > 0.2f || Mathf.Abs(agent.velocity.z) > 0.2f)
        {
            if (currentState == CurrentState.Attack)
            {
                if(agent.isStopped)
                {
                    animate.AnimateStop();
                }
                else
                {
                    animate.AnimateRun(agent.velocity.magnitude, agent.speed);
                }
                
                //Debug.Log("Chase");
                
            }
            else if (currentState == CurrentState.Partrol)
            {
                animate.AnimateWalk(agent.velocity.magnitude, agent.speed);
               
                //Debug.Log("Partrol");
            }
            else if(currentState == CurrentState.Search)
            {
                animate.AnimateSearch(controller.enemyStats.searchTurnSpeed, agent.angularSpeed);
            }
        }
        /*else
        {
            animate.AnimateWalk(agent.velocity.magnitude, agent.speed);
        }*/
        TakeDamgeNow();
        
    }

    public void TakeDamgeNow()
    {
        if (m_Var != last_var) 
        {
            //Debug.Log(last_var);
            m_Var = last_var; animate.animator.SetTrigger("damage");
            agent.isStopped = true;
        }
        if (agent.isStopped) return;
        agent.isStopped = false;
    }
    
}


