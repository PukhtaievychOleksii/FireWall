using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject BookWithRecepis;
    void OnMouseEnter()
    {
        if (PouseGame.GameIsPoused) return;
        BookWithRecepis.SetActive(true);
    }

    void OnMouseExit()
    {
        BookWithRecepis.SetActive(false);
    }
}
