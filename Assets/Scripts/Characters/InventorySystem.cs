using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventorySystem 
{
    private Dictionary<string,List<GameObject>> Inventory = new Dictionary<string,List<GameObject>>(); // (key,amount)
    private Dictionary<string, int> CurrentNumberOfItems = new Dictionary<string, int>();
    
    public InventorySystem()
    {

    }

    public void PutItemInto(string key,GameObject item)
    {
        List<GameObject> ItemGroup = new List<GameObject>();
        int ItemsAmount = 0;
        if (ItemGroupExistInInventory(key))
        {
            Inventory.TryGetValue(key + 's',out ItemGroup);
            CurrentNumberOfItems.TryGetValue(key + 's', out ItemsAmount);
        }
        else
        {
            Inventory.Add(key + 's', ItemGroup);
            CurrentNumberOfItems.Add(key + 's', ItemsAmount);
        }
        ItemGroup.Add(item);
        ItemsAmount++;
    }

    public GameObject GetItemFromInventory(string key)
    {
        if (ItemGroupExistInInventory(key))
        {
            List<GameObject> ItemGroup = new List<GameObject>();
            int ItemsAmount = 0;            
            Inventory.TryGetValue(key + 's', out ItemGroup);
            CurrentNumberOfItems.TryGetValue(key + 's', out ItemsAmount);

            GameObject gameObject = ItemGroup[0];
            ItemGroup.Remove(gameObject);
            if (ItemsAmount > 0) ItemsAmount--;
            return gameObject;
        }
        else
        {
            throw new System.Exception();
        }
        
    }
    private bool ItemGroupExistInInventory(string typeName)
    {
        return Inventory.ContainsKey(typeName + 's');
    }


    public int GetNumberOfItemsInInventoryLeft(string key)
    {
        key += 's';
        List<GameObject> ItemGroup;
        Inventory.TryGetValue(key, out ItemGroup);
        if(ItemGroup != null)
        {
            return ItemGroup.Count;
        }
        return 0;
    }

    
}
