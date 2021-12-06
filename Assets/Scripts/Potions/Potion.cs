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
    [HideInInspector]
    public string Name;
    private Transform ScalingSpace;


    void Start()
    {
        Name = Enum.GetName(typeof(PotionsType), PotionType);
        ScalingSpace = gameObject.GetComponentInChildren<Transform>();
        SetAppropriateScaling();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();  
    }

    private void SetAppropriateScaling()
    {
        if (ScalingSpace != null)
        {
            ScalingSpace.transform.localScale = new Vector3(DamageRadius, DamageRadius, ScalingSpace.transform.localScale.z);
        }
    }


}
