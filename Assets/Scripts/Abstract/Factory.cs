using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour
{
    public Dictionary<string,GameObject> PotionObjectsForCreation = new Dictionary<string, GameObject>();
    public List<GameObject> PotionPrefabs = new List<GameObject>();
    void Awake()
    {
        DataHolder.SetFactory(this);
        PotionsPrefabsToDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PotionsPrefabsToDictionary()
    {
        for(int i = 0;i < PotionPrefabs.Count; i++)
        {
            string name = PotionPrefabs[i].name;
            PotionObjectsForCreation.Add(name, PotionPrefabs[i]);
        }
    }

  

    public void AddPotion(PotionsType potionType)
    {
        string potionName = Enum.GetName(typeof(PotionsType), potionType);
        GameObject potionPrefab;
        PotionObjectsForCreation.TryGetValue(potionName, out potionPrefab);
        if (potionPrefab != null) {
            GameObject potionObject = Instantiate(potionPrefab, DataHolder.Wizzard.gameObject.transform.position, Quaternion.identity);
            potionObject.SetActive(false);
            potionObject.transform.SetParent(DataHolder.Wizzard.gameObject.transform);
            DataHolder.Wizzard.InventorySystem.PutItemInto(potionName, potionObject);
        }
    }


    public List<Sprite> GetPotionSprites()
    {
        List<Sprite> potionImages = new List<Sprite>();
        for(int i = 0;i < PotionPrefabs.Count;i++)
        {
            Potion potion = PotionPrefabs[i].GetComponent<Potion>();
            if(potion != null)
            {
                Sprite potionImage = potion.PotionImage;
                potionImages.Add(potionImage);
            }
        }
        return potionImages;
    }
    
}
