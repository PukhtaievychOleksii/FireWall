using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    public static float MasterVolume = 1f;
    private float PreviousMasterVolume = 1f;

    public static float EffectVolume = 1f;
    private float PreviousEffectVolume = 1f;

    private bool MenuIsAcctive = false;
    [SerializeField] Slider VolumeMasterSlider;
    [SerializeField] Slider VolumeEffectSlider;

    public string type; // must be set in unity where AudioSorce Is added Master / Effect
    public AudioSource AudioSource;




    // Start is called before the first frame update
    void Start()
    {
        if (VolumeMasterSlider != null)
        {
            VolumeMasterSlider.value = MasterVolume;
            VolumeEffectSlider.value = EffectVolume;
            MenuIsAcctive = true;
        }
        else
        {
            MenuIsAcctive = false;
            AudioSource = GetComponent<AudioSource>();
        }
    }

    public void OnVolumeChangeMaster(float volume)
    {
        MasterVolume = volume;
    }
    public void OnVolumeChangeEffect(float volume)
    {
        EffectVolume = volume;
    }
    public void Awake() 
    {
        if (AudioSource != null)
        {
            //Debug.Log("MASTER VOLMUNE AVAIK " + MasterVolume);
            if (type == "Master" && !MenuIsAcctive)
            {
                PreviousMasterVolume = MasterVolume;
                //Debug.Log("MASTER VOLMUNE " + MasterVolume);
                AudioSource.volume = MasterVolume;
                //DataHolder.Wizzard.UpdateMasterVolume(MasterVolume);
            }
            if (type == "Effect" && !MenuIsAcctive)
            {
                PreviousEffectVolume = EffectVolume;
                //Debug.Log("EFFECT VOLMUNE " + EffectVolume);
                AudioSource.volume = EffectVolume;
            }
        }
        
    }
   

}
