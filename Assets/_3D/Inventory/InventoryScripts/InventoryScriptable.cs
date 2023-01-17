using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("InventorySystem/CharacterInventory"))]
public class InventoryScriptable : ScriptableObject
{
    public int LuckyPower;
    public int LuckyPowerGetSet
    {
        get { return LuckyPower; }
        set { LuckyPower = value; }
    }

}
