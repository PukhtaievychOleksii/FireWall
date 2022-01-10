using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngridientsCook : MonoBehaviour
{
    public List<IngridientsType> IngridientsToConsume;
    public List<IngridientsType> ReadyIngridient;
    public float CookingTime = 5f;
    public float TimeToNextCookingTime = 5f;
    private int Is_Occupide = -1; // if < 0 then the object is free to use 
    private AudioSource AudioSource;
    public List<AudioClip> audioClips;
    [HideInInspector]
    public bool IsMouseOver = false;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void UpdateSound(float volume)
    {
        AudioSource.volume = volume;
    }

    private AudioClip RandomAudioClip() 
    {
        return audioClips[UnityEngine.Random.Range(0, audioClips.ToArray().Length)];
    }
    // Update is called once per frame
    void Update()
    {
        if (Is_Occupide >= 0)
        {
            if (PouseGame.GameIsPoused) return;
            CookingTime -= Time.deltaTime;
            if (audioClips.ToArray().Length > 0 && !AudioSource.isPlaying) // cuting bord sounds
            {
                Debug.Log("som tuna");
                AudioClip audioClip = RandomAudioClip();
                AudioSource.PlayOneShot(audioClip);
            }
            if (CookingTime < 0)
            {
                CookingTime = TimeToNextCookingTime;
                GiveReadyIngridient();
                Is_Occupide = -1;
                AudioSource.Stop();
            }
        }
        
    }

    private bool CanBeConsumed(IngridientsType ingridientType)
    {
        int counter = -1;
        foreach(IngridientsType type in IngridientsToConsume )
        {
            counter++;
            if (ingridientType == type && Is_Occupide < 0)
            {
                Is_Occupide = counter;
                return true;
            }
                
        }
        return false;
    }
    public void TryGetIngridient()
    {
        
        if (DataHolder.Wizzard.CurrentIngridient == null) return; 
        if (!CanBeConsumed(DataHolder.Wizzard.CurrentIngridient.IngridientType)) return;
        Debug.Log("TryGetIngridient" + DataHolder.Wizzard.CurrentIngridient.IngridientType);
        Consume();
    }
    public void GiveReadyIngridient()
    {
        Ingridient ingridient = DataHolder.Factory.AddIngridient(ReadyIngridient[Is_Occupide], transform.position);
        ingridient.gameObject.layer = LayerMask.NameToLayer("Default");
        
    }
    private void Consume()
    {
        Destroy(DataHolder.Wizzard.CurrentIngridient.gameObject);
        AudioSource.Play();
    }

    private void OnMouseEnter()
    {
        IsMouseOver = true;
    }

    private void OnMouseExit()
    {
        IsMouseOver = false;
    }
}
