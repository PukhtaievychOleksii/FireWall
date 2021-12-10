using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Ingridients{
    Ingridient1,
    Ingridient2,
    Ingridient3
}

public enum PotionsType
{
    Potion1 = 1,
    Potion2 = 2,
    Potion3 = 3
}
public class Potion : Projectile
{
    public List<Ingridients> IngridientsToCreate;
    public float TimeToCreate = 1f;
    public PotionsType PotionType;
    public Sprite PotionImage;
    public float DamageRadius;
    public float ActiveDamageTime;
    public float FadingTime;
    [HideInInspector]
    public string Name;
    public Transform ScalingSpace;//must be set in Unity
    private ExplosionZone ExplosionZone;
    private SpriteRenderer Renderer;
    private bool IShouldFade = false;


    void Start()
    {
        Name = Enum.GetName(typeof(PotionsType), PotionType);
        ExplosionZone = GetComponentInChildren<ExplosionZone>();
        Renderer = GetComponent<SpriteRenderer>();
        SetAppropriateScaling();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        if (IShouldFade)
        {
            Color color = Renderer.color;
            color.a -= 1 / (FadingTime * 30);
            if (color.a > 0)
            {
                Renderer.color = color;
                ExplosionZone.Renderer.color = color;
            }
        }
    }

    private void SetAppropriateScaling()
    {
        if (ScalingSpace != null)
        {
            ScalingSpace.transform.localScale = new Vector3(DamageRadius, DamageRadius, ScalingSpace.transform.localScale.z);
        }
    }

    public void Explode()
    {
        Renderer.enabled = false;
        ExplosionZone.SetOn();
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void DisablePotioning()
    {
        gameObject.SetActive(false);
        ExplosionZone.gameObject.SetActive(false);

    }

    private void StartFading()
    {
        IShouldFade = true;
    }

    public IEnumerator DestroyPotion()
    {
        StartFading();
        yield return new WaitForSeconds(ActiveDamageTime);
        DisablePotioning();
        yield return new WaitForSeconds(FadingTime - ActiveDamageTime);
        Destroy(gameObject);
        

    }


}
