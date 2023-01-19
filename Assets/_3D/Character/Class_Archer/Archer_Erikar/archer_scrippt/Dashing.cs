using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    private Character_archer archer;
    private Rigidbody rb;
    [Header("References")]
    public Transform orientation;

    [Header("Dashing")]
    [SerializeField] private float dashForec;
    private bool isDashing;
    public float dashUpwardForce;
    public float dashDuraton;

    [Header("CoolDown")]
    public KeyCode dashKey = KeyCode.C;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        archer = GetComponent<Character_archer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(dashKey) && archer.isSprinting)
        {
            // Dash();
            Debug.Log("IsSprinting");
            isDashing = true;
        }
    }

    void FixedUpdate()
    {
        //Debug.Log("Dashing" + isDashing);
        if (isDashing)
        {
            DashAbility();
        }
    }
    void DashAbility()
    {
        archer.animator.SetTrigger("diving");
        rb.AddForce(transform.forward * dashForec, ForceMode.Impulse);
        isDashing = false;
    }

    private void Dash()
    {
       

        Vector3 forceToApply = orientation.forward * dashForec + orientation.up * dashUpwardForce;
        delayedForceToApply = forceToApply;
        Invoke(nameof(DelayDashForce), 0.025f);

        Invoke(nameof(ResetDash), dashDuraton);
    }

    private Vector3 delayedForceToApply;
    private void DelayDashForce()
    {
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    private void ResetDash()
    {
        
    }
}
