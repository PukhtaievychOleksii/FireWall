using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoundCanvasButton : MonoBehaviour
{
    public AudioSource audioSource;

    public void ClickOnButton()
    {
        audioSource.volume = SoundManagerEfect.EffectVolume;
        audioSource.Play();
    }
}
