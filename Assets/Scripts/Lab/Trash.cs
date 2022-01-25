using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public bool IsMouseOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryDeleteIngridient()
    {
        DataHolder.Labaratory.RemoveIngridient();
    }

    private void OnMouseEnter()
    {
        IsMouseOver = true;
        DataHolder.Labaratory.EnableLabCursor();
        
    }

    private void OnMouseExit()
    {
        IsMouseOver = false;
    }
}
