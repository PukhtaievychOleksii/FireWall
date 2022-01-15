using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectUpdater : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("START UPDATER");
        SoundManagerEfect.SetSound();
        SoundManagerMain.SetSound();
        Debug.Log("LOADED UPDATER EFFECT");
    }
    public void UpdateEffect(AudioSource source)
    {

        Debug.Log("UPDATE EFFECT");
        source.volume = SoundManagerEfect.EffectVolume;
    }
    public void UpdateMain(AudioSource source)
    {
        source.volume = SoundManagerMain.MasterVolume;
    }
}
