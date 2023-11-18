using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<ItemSlot> itemSlots = new List<ItemSlot>();
    private ItemSlot itemSlot = new ItemSlot();

    [SerializeField]
    GameObject inventoryPanel;

    void Start()
    {
        //Read all itemSlots as children of inventory panel
        itemSlots = new List<ItemSlot>(
            inventoryPanel.transform.GetComponentsInChildren<ItemSlot>()
        );
    }
    
    public void AddItem(string itemName, int itemCount)
    {
        Item item = null;
        item.name = itemName;
        itemSlot.Count = itemCount;
    }
}



