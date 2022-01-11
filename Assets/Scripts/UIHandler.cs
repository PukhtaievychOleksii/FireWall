using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject HeartOfHpPrefab;
    public GameObject IngridientImagePrefab;
    public Canvas canvas;
    public List<GameObject> PotionImagesObjects;
    private Stack<GameObject> HeartsOfHP = new Stack<GameObject>();
    private List<GameObject> IngridientImages = new List<GameObject>();
    private const float SpaceBetweenImages = 0.5f;
    public TextMeshProUGUI FinalTextKilledMonstersText;

    private void Awake()
    {
        DataHolder.SetUIHandler(this);
        
    }
    void Start()
    {
        
        LocateHPHearts();
        UpdateStorageUI();
    }

    public void UpadteFinalTextKilledMonsters(int ScoreKilledMonsters) 
    {

        FinalTextKilledMonstersText.text = "You have killed \n " + ScoreKilledMonsters + " Monsters";
    }



    private void LocateHPHearts()
    {
        for (int i = 0; i < DataHolder.Game.Wall.HealthPoint; i++)
        {
            GameObject HeartImage = Instantiate(HeartOfHpPrefab, GetHeartsLocation(i), Quaternion.identity);
            HeartImage.transform.SetParent(canvas.transform);
            HeartsOfHP.Push(HeartImage);
        }

    }

    //TODO: Locate ingridients images
    private void LocateIngridientsImages()
    {
    
    }

   /* private Vector2 GetIngridientImageLocation(int i)
    {
        Camera WorldCamera = canvas.worldCamera;
        Vector3 Location = WorldCamera.ScreenToWorldPoint(new Vector3(0, WorldCamera.pixelHeight, 0));
        Image HeartPrefabImage = HeartOfHpPrefab.GetComponent<Image>();
        Image IngridientPrefabImage = IngridientImagePrefab.GetComponent<Image>();
        Location.x += HeartPrefabImage.rectTransform.sizeDelta.x / 2;
        Location.y -= HeartPrefabImage.rectTransform.sizeDelta.y / 2 + i * IngridientPrefabImage.rectTransform.sizeDelta.y + i * SpaceBetweenImages;
        return Location;

    }*/
    private Vector2 GetHeartsLocation(int i)
    {
        Camera WorldCamera = canvas.worldCamera;
        Vector3 HeartsLocation = WorldCamera.ScreenToWorldPoint(new Vector3(0, WorldCamera.pixelHeight, 0));
        Image Image = HeartOfHpPrefab.GetComponent<Image>();
        HeartsLocation.x += Image.rectTransform.sizeDelta.x / 2 + i * Image.rectTransform.sizeDelta.x + i * SpaceBetweenImages;
        HeartsLocation.y -= Image.rectTransform.sizeDelta.y / 2;
        return HeartsLocation;
    }

    public void RemoveHeart()
    {
        GameObject Heart = HeartsOfHP.Pop();
        Destroy(Heart);
    }


    public void UpdateStorageUI()
    {
        //UpdateStorageImages();
        UpdateStorageAmountText();
    }

    private void UpdateStorageImages()
    {
        List<GameObject> potionPrefabs = DataHolder.Factory.PotionPrefabs;
        for (int i = 0; i < PotionImagesObjects.Count; i++)
        {
            Potion potion = potionPrefabs[i].GetComponent<Potion>();
            Image image = PotionImagesObjects[i].GetComponent<Image>();
            image.sprite = potion.PotionImage;
            Text[] texts = PotionImagesObjects[i].GetComponentsInChildren<Text>();
            Text nameText = texts[1];
            nameText.text = potion.Name;
        }
    }

    
    

    private void UpdateStorageAmountText(){
        List<GameObject> potionPrefabs = DataHolder.Factory.PotionPrefabs;
        for(int i = 0;i < PotionImagesObjects.Count; i++)
        {
            Potion potion = potionPrefabs[i].GetComponent<Potion>();
            Text amountText = PotionImagesObjects[i].GetComponentsInChildren<Text>()[0];
            amountText.text = DataHolder.Wizzard.InventorySystem.GetNumberOfItemsInInventoryLeft(potion.Name).ToString();
        }
    }
    void Update()
    {
        
    }

  
}
