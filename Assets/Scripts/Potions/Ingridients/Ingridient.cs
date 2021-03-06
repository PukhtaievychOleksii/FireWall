using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngridientsType{
    Cookie,
    Mushroom,
    Fruit,
    Infusion,
    Bowl_of_Crushed_Cookies,
    Bowl_of_Cuted_Mushrums,
    Bowl_of_Cuted_Star_Fruit,
    Bowl_of_Steamed_Mushrums,
    Bowl_of_Steamed_Star_Fruit,
    Poop
}
public class Ingridient : MonoBehaviour
{
    // Start is called before the first frame update
    public IngridientsType IngridientType;

    public Collider2D Colider;
    [HideInInspector]
    public bool StickToMouse = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StickToMouse) transform.position = DataHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        if (DataHolder.Wizzard.CurrentIngridient != null)
        {
            return;
        }
        
        DataHolder.Wizzard.CurrentIngridient = this;
        if (Colider != null)
        {
            if (IngridientType.ToString() == "Poop")
            {
                Cauldron.IsPoopOccupide = false;
            }
            Colider.enabled = false;
        }
       

        StickToMouse = true;
    }

    private void OnMouseEnter()
    {
        DataHolder.Labaratory.EnableLabCursor();
    }


}
