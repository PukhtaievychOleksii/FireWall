using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngridientsCook : MonoBehaviour
{
    public List<IngridientsType> IngridientsToConsume;
    public List<IngridientsType> ReadyIngridient;
    public float CookingTime = 0f;
    private int Is_Occupide = -1; // if < 0 then the object is free to use 
    [HideInInspector]
    public bool IsMouseOver = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (ReadyIngridient.ToArray().Length == 0) 
        {
            Is_Occupide = -1;
            return;
        }
        Ingridient ingridient = DataHolder.Factory.AddIngridient(ReadyIngridient[Is_Occupide], transform.position);
        ingridient.gameObject.layer = LayerMask.NameToLayer("Default");
        
    }
    private void Consume()
    {
        Destroy(DataHolder.Wizzard.CurrentIngridient.gameObject);
        StartCoroutine(Cook());
    }

    IEnumerator Cook()
    {
        yield return new WaitForSeconds(CookingTime);
        GiveReadyIngridient();
        Is_Occupide = -1;
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
