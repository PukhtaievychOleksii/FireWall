using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IngridientsCook : MonoBehaviour
{
    public List<IngridientsType> IngridientsToConsume;
    public List<IngridientsType> ReadyIngridients;// !!!Order is important. It will give readyIngr according to the order of IngrToConsume
    public float CookingTime = 0f;
    [HideInInspector]
    public bool IsMouseOver = false;
    private int ReadyIngridientIndex = -1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CanBeConsumed(IngridientsType ingridientType)
    {
        for (int i = 0; i < IngridientsToConsume.Count; i++)
        {
            IngridientsType type = IngridientsToConsume[i];
            if (ingridientType == type)
            {
                ReadyIngridientIndex = i;
                return true;
            }
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
        if (ReadyIngridientIndex < 0 || ReadyIngridientIndex > ReadyIngridients.Count) return;
        IngridientsType ReadyIngridient = ReadyIngridients[ReadyIngridientIndex];
        Ingridient ingridient = DataHolder.Factory.AddIngridient(ReadyIngridient, transform.position);
        ingridient.gameObject.layer = LayerMask.NameToLayer("Default");
        ReadyIngridientIndex = -1;
    }
    private void Consume()
    {
        Destroy(DataHolder.Wizzard.CurrentIngridient.gameObject);
        DataHolder.Wizzard.CurrentIngridient = null;
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
