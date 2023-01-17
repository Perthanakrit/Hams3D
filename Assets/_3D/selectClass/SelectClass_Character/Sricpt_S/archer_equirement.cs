using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archer_equirement : MonoBehaviour
{
    // Start is called before the first frame update
    //[CreateAssetMenu(menuName = "Scriptabale_Objects/Inventory_System/Items/Hand_Item")]
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject weaponInHand;
    [SerializeField] private GameObject arrow;

    void Start()
    {
        
        weaponInHand.SetActive(false);
    } 

    // Update is called once per frame
    
    public void equirement()
    {
        weapon.SetActive(false);
        weaponInHand.SetActive(true);
    }
    public void WeaponInHand()
    {
        weapon.SetActive(true);
        weaponInHand.SetActive(false);
    }

    public void arrowInHand()
    {
        arrow.SetActive(true);
    }
    public void Shotarrow()
    {
        arrow.SetActive(false);
    }

}
