using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngridientsType{
    Cookie,
    Mushroom,
    Ingridient3
}
public class Ingridient : MonoBehaviour
{
    // Start is called before the first frame update
    public bool StickToMouse = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StickToMouse) transform.position = DataHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    

}
