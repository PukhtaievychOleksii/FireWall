using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionZone : MonoBehaviour
{
    [HideInInspector]
    public SpriteRenderer Renderer;
    [HideInInspector]
    public Potion Potion;
    void Start()
    {
        Renderer = gameObject.GetComponent<SpriteRenderer>();
        Potion = gameObject.GetComponentInParent<Potion>();
        SetOff();
    }

    public void SetOn()
    {
        gameObject.SetActive(true);
        Renderer.enabled = true;

    }

    public void SetOff()
    {
        gameObject.SetActive(false);
        Renderer.enabled = false;
    }
    void Update()
    {
        
    }
}
