using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsHandler : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip AlarmSound;  
    void Start()
    {
        DataHolder.SetEffectsHandler(this);
        AudioSource = GetComponent<AudioSource>();    
    }

    public void StartAlarmEffects()
    {
        if(AlarmSound != null)
        {
            AudioSource.clip = AlarmSound;
            AudioSource.Play();
        }
    }

    public void StopAlarmEffeects()
    {
        AudioSource.Stop();
    }

}
