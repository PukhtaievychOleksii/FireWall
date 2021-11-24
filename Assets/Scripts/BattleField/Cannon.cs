using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Camera MainCamera;
    public Potion Projectile;
    void Start()
    {
        DataHolder.SetCannon(this);  
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FollowMouse()
    {

     
        float ZRot = Quaternion.LookRotation(MainCamera.ScreenToWorldPoint(Input.mousePosition)).z;
        float WRot = Quaternion.LookRotation(MainCamera.ScreenToViewportPoint(Input.mousePosition)).w;
        gameObject.transform.rotation  =  new Quaternion(0,0,ZRot,WRot);
        
    }

    public void FireOnTarget(Vector3 target)
    {
        string potionName = DataHolder.Wizzard.CurrentShootingPotionType.ToString();
        int potionsLeft = DataHolder.Wizzard.InventorySystem.GetNumberOfItemsInInventoryLeft(potionName);
        if (potionsLeft > 0) {
            GameObject potionObject = DataHolder.Wizzard.InventorySystem.GetItemFromInventory(potionName);
            PutPotionInCannon(ref potionObject);
            Projectile projectile = potionObject.GetComponent<Potion>();
            projectile.SpeedUp(target);
            DataHolder.UIHandler.UpdateStorageUI();
        }
    }

    private void PutPotionInCannon(ref GameObject potionObject)
    {
        if(potionObject.GetComponent<Potion>() != null)
        {
            potionObject.transform.position = gameObject.transform.position;
            potionObject.SetActive(true);
            potionObject.transform.SetParent(potionObject.transform);
        }
    }

    public void FireOnMousePosition()
    {
        Vector3 target = DataHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
        FireOnTarget(target);
    }


}
