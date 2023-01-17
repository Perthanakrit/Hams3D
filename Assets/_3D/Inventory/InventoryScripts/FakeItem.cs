using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FakeItem 
{
    public enum ItemType{
        coin,
        LuckyKey
    }

    public ItemType itemType;
    public int amount;
}
