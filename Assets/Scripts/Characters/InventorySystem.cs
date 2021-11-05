using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventorySystem 
{
    public Dictionary<string, List<GameObject>> Inventory = new Dictionary<string, List<GameObject>>();
    
    public InventorySystem()
    {

    }

    public void PutItemInto<T>(T Item) where T: MonoBehaviour
    {
        string itemName = Item.GetType().Name;
        List<GameObject> ItemGroup = new List<GameObject>();
        if (ItemGroupExistInInventory(itemName))
        {
            Inventory.TryGetValue(itemName + 's',out ItemGroup);
        }
        else
        {
            Inventory.Add(itemName + 's', ItemGroup);
        }
        ItemGroup.Add(Item.gameObject);

    }

    public void GetItemFromInventory<T>(out T item)
    {
        List<GameObject> ItemGroup = new List<GameObject>();
        string key = typeof(T).Name + 's';
        Inventory.TryGetValue(key, out ItemGroup);
        GameObject gameObject = ItemGroup[0];
        ItemGroup.Remove(gameObject);
        item = gameObject.GetComponent<T>();
    }
    private bool ItemGroupExistInInventory(string typeName)
    {
        return Inventory.ContainsKey(typeName + 's');
    }
}
