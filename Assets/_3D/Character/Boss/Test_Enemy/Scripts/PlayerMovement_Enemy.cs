using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Enemy : MonoBehaviour
{
    public CharacterController controller;
    //public AnimateCharacter animator;
    public float speed = 10;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<AnimateCharacter>();
    }

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        //Controls are inverted, not gonna try to figure it out
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
            //animator.AnimateRun(true);
        }
        //else
            //animator.AnimateRun(false);
    }
}
