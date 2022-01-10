using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmZone : MonoBehaviour
{
    public Alarm Alarm;
    void Start()
    {
        
    }

    void Update()
    {
     
    }
    public void UpdateSound(float volume) 
    {
        Alarm.UpdateSound(volume);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Virus virus = collision.gameObject.GetComponent<Virus>();
        if (virus != null)
        {
            Alarm.OnAlarm();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Virus virus = collision.gameObject.GetComponent<Virus>();
        if (virus != null)
        {
            Alarm.StopAlarm();
        }
    }


}
