using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject HeartOfHpPrefab;
    public Canvas canvas;
    private Stack<GameObject> HeartsOfHP = new Stack<GameObject>();
    private const float SpaceBetweenHeartImages = 0.5f;
    [SerializeField]
    private Game Game;
    void Start()
    {
        LocateHPHearts();
    }

    private void LocateHPHearts()
    {
        for (int i = 0; i < Game.Wall.HealthPoint; i++)
        {
            GameObject HeartImage = Instantiate(HeartOfHpPrefab,GetHeartsLocation(i), Quaternion.identity);
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

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
