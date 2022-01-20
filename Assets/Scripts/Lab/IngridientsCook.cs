using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngridientsCook : MonoBehaviour
{
    public List<IngridientsType> IngridientsToConsume;
    public List<IngridientsType> ReadyIngridient;
    public float CookingTime = 5f;
    public float TimeToNextCookingTime = 5f;
    private int Is_Occupide = -1; // if < 0 then the object is free to use 
    private const float SpeedUpProcess = 0.25f;
    private AudioSource audioSource;
    public SoundEffectUpdater soundeffectUpdater;
    public List<AudioClip> audioClips;
    [SerializeField] Slider IngrediedtPripering;

    [HideInInspector]
    public bool IsMouseOver = false;

    public ParticleSystem effectsSteam;
    public Animator mortarAnim;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundeffectUpdater.UpdateEffect(audioSource);
        IngrediedtPripering.value = 0f;
        IngrediedtPripering.gameObject.SetActive(false);

        effectsSteam.Stop();
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
            if (PauseGame.GameIsPoused)
            {
                soundeffectUpdater.UpdateEffect(audioSource);
                return;
            }
            if (DataHolder.Wizzard.CurrentLocation == Location.BattleField)
            {
                IngrediedtPripering.gameObject.SetActive(false);
            }
            else if (DataHolder.Game.Wizzard.gameObject.transform.position.x <= -20f)
            {
                IngrediedtPripering.gameObject.SetActive(true);
            }
            
            CookingTime -= Time.deltaTime;
            if (audioClips.ToArray().Length > 0 && !audioSource.isPlaying) // cuting bord sounds
            {
                Debug.Log("som tuna");
                AudioClip audioClip = RandomAudioClip();
                audioSource.PlayOneShot(audioClip);
            }

            IngrediedtPripering.value = 1 - (CookingTime / TimeToNextCookingTime);
            if (CookingTime < 0)
            {
                CookingTime = TimeToNextCookingTime;
                GiveReadyIngridient();
                Is_Occupide = -1;
                audioSource.Stop();
                mortarAnim.SetTrigger("off");
                IngrediedtPripering.gameObject.SetActive(false);

                effectsSteam.Stop();
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
        Debug.Log("som tuna click");
        if (Is_Occupide >= 0 && CookingTime > 0)
        {
            CookingTime -= SpeedUpProcess;
        }

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
        IngrediedtPripering.gameObject.SetActive(true);
        Destroy(DataHolder.Wizzard.CurrentIngridient.gameObject);
        audioSource.Play();
        if (this.gameObject.name == "Steamer")
        {
            effectsSteam.Play();
        }
        if (this.gameObject.name == "Mortar")
        {
            mortarAnim.SetTrigger("on");
        }
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
