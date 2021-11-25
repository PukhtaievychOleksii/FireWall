using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Camera MainCamera;
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
        Projectile projectile = DataHolder.Factory.AddBullet(transform.position);
        projectile.SpeedUp(target);
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
