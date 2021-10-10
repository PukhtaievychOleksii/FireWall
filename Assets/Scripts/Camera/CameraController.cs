using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Game game;
    public GameObject StickToObject;
    private Vector3 Offset;
    void Start()
    {
        StickToObject = game.Wizzard.gameObject;
        Offset = transform.position - StickToObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = StickToObject.transform.position + Offset;
    }
}
