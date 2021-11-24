using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour,ICanAttack
{
    private bool ShouldGoToDestination = false;
    private Vector3 destination;
    public float HitTime;
    public float Damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void UpdatePosition()
    {
        if (transform.position == destination) ShouldGoToDestination = false;
        if (ShouldGoToDestination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination,HitTime);
        }else
        {
            Destroy(gameObject);
        }
<<<<<<< HEAD
    
=======

>>>>>>> 188cbbf4f71f236195a7069b5a048ec0192459a7
    }

    public void SpeedUp(Vector3 destination)
    {
        this.destination = destination;
        ShouldGoToDestination = true;
    }


    public void Blow()
    {

    }

    public void OnDestinationAchived()
    {
        Blow();
        Destroy(gameObject);
    }

    public float GiveDamage()
    {
        return Damage;
    }
}
