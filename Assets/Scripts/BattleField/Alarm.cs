using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public delegate void AlarmAction();
    public AlarmAction OnAlarm;
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Virus virus = collision.gameObject.GetComponent<Virus>();
        if(virus != null)
        {
            OnAlarm();
        }
    }


}
