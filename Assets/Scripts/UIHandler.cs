using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject HeartOfHpPrefab;
    public Canvas canvas;
    public List<GameObject> PotionImagesObjects;
    private Stack<GameObject> HeartsOfHP = new Stack<GameObject>();
    private const float SpaceBetweenHeartImages = 0.5f;

    private void Awake()
    {
        DataHolder.SetUIHandler(this);
    }
    void Start()
    {
        LocateHPHearts();
        UpdateStorageUI();
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

    private Vector2 GetHeartsLocation(int i)
    {
        Camera WorldCamera = canvas.worldCamera;
        Vector3 HeartsLocation = WorldCamera.ScreenToWorldPoint(new Vector3(0, WorldCamera.pixelHeight, 0));
        Image Image = HeartOfHpPrefab.GetComponent<Image>();
        HeartsLocation.x += Image.rectTransform.sizeDelta.x / 2 + i * Image.rectTransform.sizeDelta.x + i * SpaceBetweenHeartImages;
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
