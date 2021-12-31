using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngridientsCook : MonoBehaviour
{
    public List<IngridientsType> IngridientsToConsume;
    public IngridientsType ReadyIngridient;
    public float CookingTime = 0f;
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
        foreach(IngridientsType type in IngridientsToConsume)
        {
            if (ingridientType == type) return true;
        }
        return false;
    }
    public void TryGetIngridient()
    {
        if (DataHolder.Wizzard.CurrentIngridient == null) return;
        if (!CanBeConsumed(DataHolder.Wizzard.CurrentIngridient.IngridientType)) return;
        Consume();
    }
    public void GiveReadyIngridient()
    {
        Ingridient ingridient = DataHolder.Factory.AddIngridient(ReadyIngridient, transform.position);
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
