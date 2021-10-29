using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public GameObject StickToObject;
    private Vector3 Offset;
    void Start()
    {
        StickToObject = DataHolder.Game.Wizzard.gameObject;
        Offset = transform.position - StickToObject.transform.position;
        DataHolder.SetMainCamera(GetComponent<Camera>());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = StickToObject.transform.position + Offset;
    }
}
