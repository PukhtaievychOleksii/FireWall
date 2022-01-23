using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSoundEffectUpdater : MonoBehaviour
{
    public AudioSource audioSourceClick;
    public AudioSource audioSourceMainSound;
    public SoundEffectUpdater soundEffectUpdater;
    public void Update()
    {
        soundEffectUpdater.UpdateEffect(audioSourceClick);
        soundEffectUpdater.UpdateMain(audioSourceMainSound);
    }
    public void ClickOnButton()
    {
        audioSourceClick.Play();
    }
}
