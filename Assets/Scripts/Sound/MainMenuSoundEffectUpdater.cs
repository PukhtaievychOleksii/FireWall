using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSoundEffectUpdater : MonoBehaviour
{
    public AudioSource audioSourceClick;
    public AudioSource audioSourceMainSound;
    public SoundEffectUpdater soundEffectUpdater;
    public void Start()
    {
        Cursor.visible = true;
    }

    public void Update()
    {
        soundEffectUpdater.UpdateEffect(audioSourceClick);
        if (audioSourceMainSound != null)
        {
            soundEffectUpdater.UpdateMain(audioSourceMainSound);
        }
        
    }
    public void ClickOnButton()
    {
        audioSourceClick.Play();
    }
}
