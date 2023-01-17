using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public GameObject ArrowPrefab;
    RaycastHit hit;
    float range = 1000f;
    public Transform ArrowSpawnPosition;
    public float shootForce = 2f;

    Vector3 lookPos;

    public void LookFor()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - this.transform.position;
        lookDir.y = 0;

        this.transform.LookAt(this.transform.position + lookDir, Vector3.up);
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire");
            Shooting();
        }
    }
        
    public void Shooting()
    {
        GameObject bullet = Instantiate(ArrowPrefab, ArrowSpawnPosition.transform.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(ArrowSpawnPosition.forward * shootForce, ForceMode.Impulse);
        Destroy(bullet, 1f);
        
    }


}
