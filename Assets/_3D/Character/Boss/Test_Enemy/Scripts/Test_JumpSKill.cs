using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test_JumpSKill : MonoBehaviour
{
    // Start is called before the first frame update
    private FieldOfView_Boss _fieldofview;
    [Header("Jumping")]
    public float jumpSpeed = 2.0f;
    private bool hasRooToJump;
    private Vector3 jumpLandPoint;
    private Vector3 jumpStartPoint;
    private float startTime;
    private float jumpTimerReset;
    private bool startJump;
    private bool endJump;
    private bool jumpResetNavMesh;
    public float distToTarget;
    public bool testJump;
    public GameObject TempCube;
    public float testLenght;
    public bool showJumpArea;

    private EnemyBoss enemy;
    private CharacterController player;
    void Start()
    {
        player = GetComponent<CharacterController>();
        _fieldofview = GetComponent<FieldOfView_Boss>();
        enemy = GetComponent<EnemyBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        if(testJump)
        {
            GetTargetDist();
            if(hasRooToJump)
            {
                jumpSetUp(_fieldofview);
                testJump = false;
            }
        }
    }

    public void GetTargetDist()
    {
        distToTarget = Vector3.Distance(transform.position, _fieldofview.visibleTarget.position);
    }

    public void jumpSetUp(FieldOfView_Boss fov)
    {
        var lookPos = fov.visibleTarget.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 999999);
        float jumpLeght;

        jumpLeght = distToTarget + 1;
        testLenght = jumpLeght + 1;

        NavMeshHit hit;
        if(NavMesh.SamplePosition(transform.position + transform.TransformDirection(new Vector3(0,0, jumpLeght)), out hit, 7.0f, NavMesh.AllAreas))
        {
            if(enemy.agent.enabled)
            {
                enemy.agent.isStopped = true;
                enemy.agent.enabled = false;
            }

            jumpLandPoint = hit.position + new Vector3(0, 1, 0);
            if (showJumpArea)
            {
                Instantiate(TempCube, hit.position, Quaternion.identity);
            }
        }
    }
    
    public void Jump()
    {
        StartCoroutine(OffNavMesh());
        jumpStartPoint = transform.position;
        startJump = true;
        endJump = false;
    }

    public void OnCollisionEnter()
    {
        if(jumpResetNavMesh)
        {
            if(_fieldofview.visibleTarget.GetComponent<CharacterController>().isGrounded)
            {
                enemy.agent.enabled = true;
            }
            if(enemy.agent.isOnNavMesh)
            {
                jumpResetNavMesh = false;
            }
            else
            {
                jumpResetNavMesh = true;
                enemy.agent.enabled = false;
            }
        }
    }

    IEnumerator OffNavMesh()
    {
        yield return new WaitForSeconds(0.5f);
        enemy.agent.enabled = false;
    }

    IEnumerator RestartNavMesh()
    {
        yield return new WaitForSeconds(0.1f);
        if(_fieldofview.visibleTarget.GetComponent<CharacterController>().isGrounded)
        {
            enemy.agent.enabled = true;
        }
        else
        {
            jumpResetNavMesh = true;
        }
    }

    public void StopJump()
    {
        startJump = false;
        jumpTimerReset = 0;
        StartCoroutine(RestartNavMesh());

    }

}
