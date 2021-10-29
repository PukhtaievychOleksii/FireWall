using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Character , ICanAttack,IDamageable
{
    public int Damage = 1;
    public float Health = 1;
    void Start()
    {
        GoToWall(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToWall()
    {
        MoveTo(GetVirusDestination(Game.Wall.gameObject.transform.position));
    }

    private Vector3 GetVirusDestination(Vector3 AimPosition)
    {
        float XPos;
        float YPos;
        float ZPos;
        XPos = AimPosition.x;
        YPos = gameObject.transform.position.y;
        ZPos = gameObject.transform.position.z;
        return new Vector3(XPos, YPos, ZPos);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public float GiveDamage()
    {
        return Damage;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0) OnDeath();
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if(projectile != null)
        {
            TakeDamage(projectile.GiveDamage());
            Destroy(projectile.gameObject);
        }
    }

}
