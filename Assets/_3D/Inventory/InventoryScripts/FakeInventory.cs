using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeInventory 
{
    public event EventHandler OnItemListChanged;
    List<FakeItem> itemsList;

    public FakeInventory()
    {
        itemsList = new List<FakeItem>();

        AddItem(new FakeItem { 
            itemType = FakeItem.ItemType.LuckyKey, 
            amount = 1 }); // new class FakeItem in this class.

        Debug.Log("Inventory");
    }

    public void AddItem(FakeItem item)
    {
        itemsList.Add(item);
        OnItemListChanged.Invoke(this, EventArgs.Empty);
    }

    public List<FakeItem> GetItemList()
    {
        return itemsList;
    }
}
