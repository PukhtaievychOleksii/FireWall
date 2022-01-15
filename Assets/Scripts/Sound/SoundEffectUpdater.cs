using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectUpdater : MonoBehaviour
{
    private void Start()
    {
        SoundManagerEfect.SetSound();
        SoundManagerMain.SetSound();
    }
    public void UpdateEffect(AudioSource source)
    {

        source.volume = SoundManagerEfect.EffectVolume;
    }
    public void UpdateMain(AudioSource source)
    {
        source.volume = SoundManagerMain.MasterVolume;
    }
}
