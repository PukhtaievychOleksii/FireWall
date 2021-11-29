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
        //AlarmObject.GetComponent<Renderer>().material.color = Color.green;
        Debug.Log("VIRUS ALEARM : "+virus.CharacterGameObject.name+"    "+AlarmObject.name);
        var cubeRenderer = AlarmObject.GetComponent<Renderer>();

        cubeRenderer.material.color = Color.green;
        //var AlarmRenderer = AlarmObject.GetComponent<Renderer>();
        //AlarmRenderer.material.SetColor("_Color", Color.red);
        if (virus != null)
        {
            OnAlarm();
        }
    }


}
