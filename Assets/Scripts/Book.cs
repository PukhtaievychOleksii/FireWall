using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject BookWithRecepis;
    void OnMouseEnter()
    {
        if (PauseGame.GameIsPaused) return;
        BookWithRecepis.SetActive(true);
    }

    void OnMouseExit()
    {
        BookWithRecepis.SetActive(false);
    }
}
