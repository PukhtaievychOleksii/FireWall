using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManagerMain : MonoBehaviour
{
    public static float MasterVolume = 1f;
    
    [SerializeField] Slider VolumeMainSlider;
    public AudioSource MainMenu;



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
        if (MainMenu)
        {
            MainMenu.volume = MasterVolume;
        }
        //PlayerPrefs.Save();
    }
    public void LoadVolume()
    {
        MasterVolume = PlayerPrefs.GetFloat("MasterVolume");
        VolumeMainSlider.value = MasterVolume;
        if (MainMenu)
        {
            MainMenu.volume = MasterVolume;
        }
    }

    public static void SetSound()
    {

        if (!PlayerPrefs.HasKey("MasterVolume"))
        {
            MasterVolume = 1f;
        }
        else
        {
            MasterVolume = PlayerPrefs.GetFloat("MasterVolume");
        }
    }


}
