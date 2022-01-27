using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource audioSource;
    private SpriteRenderer renderer;
    public SoundEffectUpdater soundeffectUpdater;
    public string setting;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        soundeffectUpdater.UpdateEffect(audioSource);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (PauseGame.GameIsPaused)
        {
            audioSource.mute = !AdvacentSetting.GetSetting(setting);
            soundeffectUpdater.UpdateEffect(audioSource);
            return;
        }
    }
    

    public void OnAlarm()
    {

        gameObject.SetActive(true);
        DataHolder.EffectsHandler.StartAlarmEffects();
        
    }

    public void StopAlarm()
    {
        gameObject.SetActive(false);
        DataHolder.EffectsHandler.StopAlarmEffeects();
    }
   


}
