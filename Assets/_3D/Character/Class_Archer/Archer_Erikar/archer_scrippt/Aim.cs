using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private LayerMask Enemy;
    private Camera mainCamera;
    [Range(0, 10)]
    [SerializeField] float rotate;
    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Aimm();
    }
    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, Enemy))
        {
            //The Raycast hit something, return with the position
            return (success: true, position: hitInfo.point);
        }
        else
        {
            //The Raycast didn't hit anything
            return (success: false, position: Vector3.zero);
        }
    }

    private void Aimm()
    {
        var (success, positon) = GetMousePosition();
        if (success)
        {
            //Calculate the direction
            var direction = positon - transform.position;

            direction.y = 0;

            //Make the transform look in the direction
            //transform.forward = direction;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotate);
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
