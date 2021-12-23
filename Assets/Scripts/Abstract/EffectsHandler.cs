using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsHandler : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip AlarmSound;
    public GameObject realAlarm;

    void Start()
    {
        DataHolder.SetEffectsHandler(this);
        AudioSource = GetComponent<AudioSource>();
        realAlarm = GameObject.Find("AlarmLight");
    }

    public void StartAlarmEffects()
    {
        realAlarm.GetComponent<Animator>().SetTrigger("on");

        if(AlarmSound != null)
        {
            AudioSource.clip = AlarmSound;
            AudioSource.Play();
        }
    }

    public void StopAlarmEffeects()
    {
        realAlarm.GetComponent<Animator>().SetTrigger("off");
        AudioSource.Stop();
    }

}
