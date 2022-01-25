using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngridientSource : MonoBehaviour
{
    // Start is called before the first frame update
    public IngridientsType IngridientType;
    [HideInInspector]
    public bool IsMouseOver = false;
    void Start()
    {
       // StartCoroutine(test());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveIngridient()
    {
        if (DataHolder.Wizzard.CurrentLocation == Location.BattleField) return;
        if (DataHolder.Wizzard.CurrentIngridient != null) return;
        Vector3 pos = DataHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
        Ingridient ingridient = DataHolder.Factory.AddIngridient(IngridientType, pos);
        ingridient.StickToMouse = true;
        DataHolder.Wizzard.CurrentIngridient = ingridient;
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(5);
        GiveIngridient();
    }

   
    public void OnMouseEnter()
    {
        IsMouseOver = true;
        DataHolder.Labaratory.EnableLabCursor();
        
    }

    public void OnMouseExit()
    {
        IsMouseOver = false;
    }
}
