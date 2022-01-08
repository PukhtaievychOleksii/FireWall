using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thresh : MonoBehaviour
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
    }

    private void OnMouseExit()
    {
        IsMouseOver = false;
    }
}
