using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public delegate void AlarmAction();
    public AlarmAction OnAlarm;
    public GameObject AlarmObject; // must be set in Unity
    void Start()
    {
        
    }

    void Update()
    {
     
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Virus virus = collision.gameObject.GetComponent<Virus>();
        Debug.Log("VIRUS ALEARM : ",virus);
        if (virus != null)
        {
            var AlarmRenderer = AlarmObject.GetComponent<Renderer>();
            AlarmRenderer.material.SetColor("_Color", Color.red);
            OnAlarm();
        }
    }


}
