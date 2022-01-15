using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource audioSource;
    private SpriteRenderer renderer;
    public SoundEffectUpdater soundeffectUpdater;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        soundeffectUpdater.UpdateEffect(audioSource);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (PouseGame.GameIsPoused)
        {
            soundeffectUpdater.UpdateEffect(audioSource);
            return;
        }
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
