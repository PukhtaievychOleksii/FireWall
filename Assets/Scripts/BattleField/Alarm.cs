using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource AudioSource;
    private SpriteRenderer renderer;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        AudioSource = GetComponent<AudioSource>();
        gameObject.SetActive(false);
    }

    void Update()
    {
     
    }
    public void UpdateSound(float volume)
    {
        AudioSource.volume = volume;
    }

    public void OnAlarm()
    {
        gameObject.SetActive(true);
        //renderer.enabled = true;
        DataHolder.EffectsHandler.StartAlarmEffects();
    }

    public void StopAlarm()
    {
        gameObject.SetActive(false);
        //renderer.enabled = false;
        DataHolder.EffectsHandler.StopAlarmEffeects();
    }
   


}
