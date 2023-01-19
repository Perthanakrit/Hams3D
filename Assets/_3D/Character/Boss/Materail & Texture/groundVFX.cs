using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundVFX : MonoBehaviour
{
    [SerializeField] private GameObject parti;
    [SerializeField] private Transform point;
    //[SerializeField ]public GameObject obj;
    private CapsuleCollider _capcollider;
  
    private void Start()
    {
        Debug.Log("jumpattack");
        _capcollider = GetComponentInParent<CapsuleCollider>();
    }
    
    public void ActiveVFXGround()
    {
        //Instantiate(prefab, point.position, point.rotation);
        //parti[p].SetActive(true);
        Instantiate(parti, point.position, point.rotation);
       // obj.GetComponentInParent<CapsuleCollider>().enabled = true;
        //_capcollider.enabled = false;
        //partSys.Play();

    }
    
    public void NotActive()
    {
        //_collider.enabled = false;
       // obj.GetComponentInParent<CapsuleCollider>().enabled = false;
        //_capcollider.enabled = true;
       
    }
}
