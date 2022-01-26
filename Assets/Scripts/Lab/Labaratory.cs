using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labaratory : MonoBehaviour
{
    public List<IngridientSource> Sources = new List<IngridientSource>();
    public List<IngridientsCook> Cooks = new List<IngridientsCook>();
    public Cauldron Culdorn;
    public Trash Trash;
    public GameObject LabCursor;
    void Awake()
    {
        DataHolder.SetLabaratory(this);
        DisableLabCursor();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 CursorPos = DataHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
        LabCursor.transform.position = CursorPos;
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

    public void EnableLabCursor()
    {
        //Cursor.visible = false;
        LabCursor.SetActive(true);
        LabCursor.GetComponentInChildren<SpriteRenderer>().enabled = true;
        //LabCursor.GetComponentInChildren<LabCursor>().SetMagicEffect(true);
    }

    public void DisableLabCursor()
    {
        //Cursor.visible = true;
        LabCursor.SetActive(false);
        LabCursor.GetComponentInChildren<SpriteRenderer>().enabled = false;
       // LabCursor.GetComponentInChildren<LabCursor>().SetMagicEffect(false);
    }

    private void OnMouseEnter()
    {
        EnableLabCursor();
    }

    private void OnMouseExit()
    {
        DisableLabCursor();
    }
}
