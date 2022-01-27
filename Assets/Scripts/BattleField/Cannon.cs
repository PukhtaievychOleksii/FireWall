using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Camera MainCamera;
    public Potion Projectile;
    private AudioClip CanonCanShoot;
    private AudioClip CanonCanNOTShoot;
    private AudioSource audioSource;
    public SoundEffectUpdater soundeffectUpdater;
    public bool CanShoot = false;
    void Start()
    {
        DataHolder.SetCannon(this);
        CanonCanShoot = Resources.Load<AudioClip>("CAN");
        CanonCanNOTShoot = Resources.Load<AudioClip>("CANNOT");
        audioSource = GetComponent<AudioSource>();
        soundeffectUpdater.UpdateEffect(audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseGame.GameIsPaused)
        {
            soundeffectUpdater.UpdateEffect(audioSource);
            return;
        }
    }

    public void FollowMouse()
    {


        /* float ZRot = Quaternion.LookRotation(MainCamera.ScreenToWorldPoint(Input.mousePosition)).z;
         float WRot = Quaternion.LookRotation(MainCamera.ScreenToViewportPoint(Input.mousePosition)).w;
         gameObject.transform.rotation  =  new Quaternion(0,0,ZRot,WRot);*/
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(MainCamera.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, MainCamera.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x) * Mathf.Rad2Deg);

    }

    public void FireOnTarget(Vector3 target)
    {
        string potionName = DataHolder.Wizzard.CurrentShootingPotionType.ToString();
        int potionsLeft = DataHolder.Wizzard.InventorySystem.GetNumberOfItemsInInventoryLeft(potionName);
        if (potionsLeft > 0 && CanShoot)
        {
            GameObject potionObject = DataHolder.Wizzard.InventorySystem.GetItemFromInventory(potionName);
            PutPotionInCannon(ref potionObject);
            Projectile projectile = potionObject.GetComponent<Potion>();
            projectile.SpeedUp(target);
            DataHolder.UIHandler.UpdateStorageUI();
            audioSource.PlayOneShot(CanonCanShoot);
        }
        else
        {
            audioSource.PlayOneShot(CanonCanNOTShoot);
        }
    }
    

    private void PutPotionInCannon(ref GameObject potionObject)
    {
        if(potionObject.GetComponent<Potion>() != null)
        {
            potionObject.transform.position = gameObject.transform.position;
            potionObject.SetActive(true);
            potionObject.transform.SetParent(null);
        }
    }

    public void FireOnMousePosition()
    {
        if (MainCamera.transform.position.x >= 0) // oprava bugu s strelanim ak sme neni v hernom poly .
        {
            Vector3 target = DataHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            FireOnTarget(target);
        }

    }


}
