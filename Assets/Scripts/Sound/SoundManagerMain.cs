using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManagerMain : MonoBehaviour
{
    public static float MasterVolume = 1f;
    
    [SerializeField] Slider VolumeMainSlider;



    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("MasterVolume"))
        {
            SaveVolume();
        }
        else
        {
            LoadVolume();
        }
    }
    public void OnVolumeChangeMaster(float volume)
    {
        MasterVolume = volume;
        SaveVolume();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
    }
    public void LoadVolume()
    {
        MasterVolume = PlayerPrefs.GetFloat("MasterVolume");
        VolumeMainSlider.value = MasterVolume;
    }

}
