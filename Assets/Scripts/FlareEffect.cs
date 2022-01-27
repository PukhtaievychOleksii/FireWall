using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareEffect : MonoBehaviour
{
    public Animator flare;

    void OnMouseEnter()
    {
        flare.SetTrigger("Hover");
    }

}
