using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labaratory : MonoBehaviour
{
    public List<IngridientSource> Sources = new List<IngridientSource>();
    public List<IngridientsCook> Cooks = new List<IngridientsCook>();
    public Cauldron Culdorn;
    void Awake()
    {
        DataHolder.SetLabaratory(this);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IngridientSource TryGetIngridientSource()
    {
      foreach(IngridientSource source in Sources)
       {
            if (source.IsMouseOver == true) return source;
       }
        return null;
    }

    public IngridientsCook TryGetIngridientCook()
    {
        foreach(IngridientsCook cook in Cooks)
        {
            if (cook.IsMouseOver == true)
            {
                return cook;
            }
        }
        return null;
    }


   

    public void RemoveIngridient()
    {
        if (DataHolder.Wizzard.CurrentIngridient == null) return;
        Destroy(DataHolder.Wizzard.CurrentIngridient.gameObject);
        DataHolder.Wizzard.CurrentIngridient = null;
    }
}
