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
    [HideInInspector]
    public string Name;


    void Start()
    {
        Name = Enum.GetName(typeof(PotionsType), PotionType);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();  
    }


}
