using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoundCanvasButton : MonoBehaviour
{
    public AudioSource audioSource;
    private void Start()
    {
        SoundManagerEfect.SetSound();
    }
    public void ClickOnButton()
    {
        audioSource.volume = SoundManagerEfect.EffectVolume;
        audioSource.Play();
    }
}
