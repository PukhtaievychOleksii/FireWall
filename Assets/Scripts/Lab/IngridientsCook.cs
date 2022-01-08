using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngridientsCook : MonoBehaviour
{
    public List<IngridientsType> IngridientsToConsume;
    public List<IngridientsType> ReadyIngridient;
    public float CookingTime = 5f;
    public float TimeToNextCookingTime = 5f;
    private int Is_Occupide = -1; // if < 0 then the object is free to use 
    [HideInInspector]
    public bool IsMouseOver = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Is_Occupide >= 0)
        {
            if (PouseGame.MenuIsActive) return;
            CookingTime -= Time.deltaTime;
            if (CookingTime < 0)
            {
                CookingTime = TimeToNextCookingTime;
                GiveReadyIngridient();
                Is_Occupide = -1;
            }
        }
        
    }

    private bool CanBeConsumed(IngridientsType ingridientType)
    {
        int counter = -1;
        foreach(IngridientsType type in IngridientsToConsume )
        {
            counter++;
            if (ingridientType == type && Is_Occupide < 0)
            {
                Is_Occupide = counter;
                return true;
            }
                
        }
        return false;
    }
    public void TryGetIngridient()
    {
        
        if (DataHolder.Wizzard.CurrentIngridient == null) return; 
        if (!CanBeConsumed(DataHolder.Wizzard.CurrentIngridient.IngridientType)) return;
        Debug.Log("TryGetIngridient" + DataHolder.Wizzard.CurrentIngridient.IngridientType);
        Consume();
    }
    public void GiveReadyIngridient()
    {
        Ingridient ingridient = DataHolder.Factory.AddIngridient(ReadyIngridient[Is_Occupide], transform.position);
        ingridient.gameObject.layer = LayerMask.NameToLayer("Default");
        
    }
    private void Consume()
    {
        Destroy(DataHolder.Wizzard.CurrentIngridient.gameObject);
    }

    private void OnMouseEnter()
    {
        IsMouseOver = true;
    }

    private void OnMouseExit()
    {
        IsMouseOver = false;
    }
}
