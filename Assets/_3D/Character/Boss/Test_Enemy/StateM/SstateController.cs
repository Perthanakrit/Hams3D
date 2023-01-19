using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SstateController : MonoBehaviour
{
    #region Private
    public Transform eyes;
    #endregion
    public EnemyStats enemyStats;
    public StateAI currentState;
    public StateAI remainState;

    [Header("Skills")]
    public EnemyBoss enemy;
    //public AbllitySys[] skills;
    [HideInInspector] public bool useAbility;
    [HideInInspector] public bool attacking;
    [HideInInspector] public Vector3 speedBeforeAttacking;

    [HideInInspector] public NavMeshAgent agent;
    //[HideInInspector] public Shoot attack;
    public List<Transform> waypoint;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform target;
    [HideInInspector] public Vector3 lastKwonTargetPostion;
    [HideInInspector] public bool stateBoolVariable; 
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public AnimateBoss characterAnim;
    [HideInInspector] public Combat _combat;
    [HideInInspector] public Rigidbody rb;

    private bool _isActive;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        //attack = GetComponent<Shoot>();
        characterAnim = GetComponent<AnimateBoss>();
        _combat = GetComponent<Combat>();
    }

    

    private void Update()
    {
        if (!_isActive) return;
        currentState.UpdateState(this);
    }

    public void InitializeAI(bool activate, List<Transform> waypointList)
    {
        waypoint = waypointList;
        _isActive = activate;
        agent.enabled = _isActive;
    }

    public void TransitionToState(StateAI nextState)
    {
        if(nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }    
    }

    public bool HasTimeElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        if(stateTimeElapsed >= duration)
        {
            stateTimeElapsed = 0;
            return true;
        }
        else
        {
            return false;
        }  
    }

    private void OnExitState()
    {
        stateBoolVariable = false;
        stateTimeElapsed = 0;
    }

    private void OnDrawGizmos()
    {
        if(currentState != null)
        {
            Gizmos.color = currentState.qizmoColor;
            Gizmos.DrawWireSphere(eyes.position, 1.9f);
        }
    }
}
