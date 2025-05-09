using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerItemDrop : ItemDrop
{
    [Header("Player's drop")]
    [SerializeField] private float chanceToLoseItems;
    [SerializeField] private float chanceToLoseMaterials;

    public override void GenerateDrop()
    {
        Inventory inventory = Inventory.instance;
        List<InventoryItem> itemToUnequipment = new List<InventoryItem>();
        List<InventoryItem> materialsToLose = new List<InventoryItem>();

        foreach (InventoryItem item in inventory.GetEquipmentList())
        {
            if (Random.Range(0, 100) <= chanceToLoseItems)
            {
                DropItem(item.data);
                itemToUnequipment.Add(item);
            }
        }
        for (int i = 0; i < itemToUnequipment.Count; i++)
        {
            inventory.UnequipItem(itemToUnequipment[i].data as ItemData_Equipment);            
        }

        foreach(InventoryItem item in inventory.GetStashList())
        {
            if (Random.Range(0, 100) <= chanceToLoseMaterials)
            {
                DropItem(item.data);
                materialsToLose.Add(item);
            }
        }

        for(int i = 0;i < materialsToLose.Count;i++)
        {
            inventory.RemoveItem(materialsToLose[i].data);
        }
    }
}
