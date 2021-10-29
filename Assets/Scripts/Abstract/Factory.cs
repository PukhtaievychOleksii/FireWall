using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    void Start()
    {
        DataHolder.SetFactory(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Projectile AddBullet(Vector3 position)
    {
        Quaternion rotation = Quaternion.EulerAngles(DataHolder.Cannon.transform.rotation.eulerAngles.x,DataHolder.Cannon.transform.rotation.eulerAngles.y, DataHolder.Cannon.transform.rotation.eulerAngles.z + 90); 
        return Instantiate(ProjectilePrefab, position,rotation).GetComponent<Projectile>();
    }
}
