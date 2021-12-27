using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour
{
    private Dictionary<string,GameObject> PotionObjectsForCreation = new Dictionary<string, GameObject>();
    public List<GameObject> PotionPrefabs = new List<GameObject>();
    public List<GameObject> IngridientsPrefabs = new List<GameObject>();
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

    public Ingridient AddIngridient(IngridientsType ingridientType, Vector3 position)
    {
        string ingridientName = Enum.GetName(typeof(IngridientsType), ingridientType);
        GameObject ingridientPrefab = GetIngridientsPrefabByName(ingridientName);
        if(ingridientPrefab != null)
        {
            GameObject ingridientObject = Instantiate(ingridientPrefab, position, Quaternion.identity);
            return ingridientObject.GetComponent<Ingridient>();
          
        }
        return null;

    }

    public GameObject GetIngridientsPrefabByName(string name)
    {
        for(int i = 0;i < IngridientsPrefabs.Count; i++)
        {
            if (IngridientsPrefabs[i].name == name) return IngridientsPrefabs[i];
        }
        return null;
    }
    public List<Sprite> GetPotionSprites()
    {
        List<Sprite> potionImages = new List<Sprite>();
        for(int i = 0;i <= PotionPrefabs.Count;i++)
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
