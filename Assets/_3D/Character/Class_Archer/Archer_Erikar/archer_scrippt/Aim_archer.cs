using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim_archer : MonoBehaviour
{
    #region Private
    [SerializeField] private LayerMask Enemy;
    private Camera mainCamera;
    [Range(0,5)]
    [SerializeField] private float speedRoate;
    private Vector3 currentPos;
    [SerializeField] Quaternion target;
    
    #endregion
    public bool isAttacking;
    private Character_archer character;

    private void Start()
    {
        mainCamera = Camera.main;
        character = GetComponent<Character_archer>();
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.Mouse0)) Debug.Log("Left Click");
        Aimm();
    }
    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, Enemy))
        {
            //The Raycast hit something, return with the position
            //istracking = true;
            return (success: true, position: hitInfo.point);
        }
        else
        {
            //The Raycast didn't hit anything
            //istracking = false;
            return (success: false, position: Vector3.zero);
        }
    }

    private void Aimm()
    {
        var (success, positon) = GetMousePosition();
        if (success && (isAttacking|| !character.enabled))
        {
            //Calculate the direction
            var direction = positon - transform.position;

            direction.y = 0;

            //Make the transform look in the direction
            //transform.forward = direction;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            target = targetRotation;

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedRoate);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target, speedRoate);
            //target.eulerAngles = Vector3.zero;         
        }
    }


    /*private void OnDrawGizmos()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, float.MaxValue, Enemy))
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(ray.origin, hitInfo.point);
            Gizmos.DrawWireSphere(ray.origin, 0.5f);
        }

    }*/

}
