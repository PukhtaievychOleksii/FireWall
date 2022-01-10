using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerMainControler : MonoBehaviour
{
    public AlarmZone alarmZone;
    // Start is called before the first frame update
    void Start()
    {
        DataHolder.SetSoundManager(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSound()
    {
        DataHolder.Wizzard.UpdateSound(SoundManagerMain.MasterVolume);
        DataHolder.Cannon.UpdateSound(SoundManagerEfect.EffectVolume);
        alarmZone.UpdateSound(SoundManagerEfect.EffectVolume);
        foreach (IngridientsCook item in DataHolder.Labaratory.Cooks)
        {
            item.UpdateSound(SoundManagerEfect.EffectVolume);
        }
        


    }
    public void UpdateSoundEffect(AudioSource audio)
    {
        audio.volume = SoundManagerEfect.EffectVolume;
    }
}
