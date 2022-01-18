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
    [SerializeField]
    private SpriteRenderer Renderer;
    private bool IShowPreparing = false;
    private float FadingOnPerFrame;
    void Active()
    {
    }

    public void StartPreparingShow(float preparingTime)
    {
        Renderer = GetComponent<SpriteRenderer>();
        FadingOnPerFrame = 1f / preparingTime / 60;
        IShowPreparing = true;
        Renderer.color = new Color(Renderer.color.r, Renderer.color.g, Renderer.color.b, 0);
    }
    public void StopPreparingShow()
    {
        IShowPreparing = false;
        gameObject.layer = LayerMask.NameToLayer("Default");

    }

    // Update is called once per frame
    void Update()
    {
        if (StickToMouse) transform.position = DataHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (IShowPreparing)
        {
            Renderer.color = new Color(Renderer.color.r, Renderer.color.g, Renderer.color.b, Renderer.color.a + FadingOnPerFrame);
            if (1 - Renderer.color.a <=0.01) StopPreparingShow();
        }

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

}
