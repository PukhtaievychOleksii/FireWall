using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManagerEfect : MonoBehaviour
{
    
    public static float EffectVolume = 1f;
    [SerializeField] Slider VolumeEfectSlider;




    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("EffectVolume"))
        {
            SaveVolume();
        }
        else
        {
            LoadVolume();
        }
    }
    public void OnVolumeChangeEffect(float volume)
    {
        EffectVolume = volume;
        SaveVolume();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("EffectVolume", EffectVolume);
    }
    public void LoadVolume()
    {
        EffectVolume = PlayerPrefs.GetFloat("EffectVolume");
        VolumeEfectSlider.value = EffectVolume;
    }



}
