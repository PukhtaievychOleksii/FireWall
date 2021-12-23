using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngridientSource : MonoBehaviour
{
    // Start is called before the first frame update
    public IngridientsType IngridientType;
    void Start()
    {
        StartCoroutine(test());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveIngridient()
    {
        Vector3 pos = DataHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
        Ingridient ingridient = DataHolder.Factory.AddIngridient(IngridientType, pos);
        ingridient.StickToMouse = true;
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(5);
        GiveIngridient();
    }
}
