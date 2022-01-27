using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{

    public AudioSource audio;
    public string setting;

    // Start is called before the first frame update
    void Start()
    {
        AudioMute(AdvacentSetting.GetSetting(setting));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioMute(bool isMuteted)
    {
        audio.mute = AdvacentSetting.GetSetting(setting);
    }
}
