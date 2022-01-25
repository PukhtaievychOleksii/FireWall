using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionZone : MonoBehaviour
{
    [HideInInspector]
    public SpriteRenderer Renderer;
    [HideInInspector]
    public Potion Potion;

    public ParticleSystem boom;

    void Start()
    {
        Renderer = gameObject.GetComponent<SpriteRenderer>();
        Potion = gameObject.GetComponentInParent<Potion>();
        SetOff();
    }

    public void SetOn()
    {
        boom.Play();
        gameObject.SetActive(true);
        //Renderer.enabled = true;

    }

    public void SetOff()
    {
        gameObject.SetActive(false);
        //Renderer.enabled = false;
    }
    void Update()
    {
        
    }
}
