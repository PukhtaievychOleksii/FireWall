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
            transform.position = Vector3.MoveTowards(transform.position, destination, HitTime);
        }
        else { // destroy object also if there was no monster
            if (this is Potion)
            {
                (this as Potion).Explode();
                StartCoroutine((this as Potion).DestroyPotion());

            }
            //Destroy(gameObject);
        }

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
