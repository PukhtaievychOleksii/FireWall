using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour , IDamageable
{
    public float HealthPoint = 2;
    private AudioSource audioSource;
    public SoundEffectUpdater soundeffectUpdater;
    public GameObject LabCursor;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundeffectUpdater.UpdateEffect(audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseGame.GameIsPaused)
        {
            soundeffectUpdater.UpdateEffect(audioSource);
            return;
        }
    }

  

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Virus virus = collision.GetComponent<Virus>();
        if (virus != null)
        {
            virus.Destroy();
            audioSource.Play();
            StartCoroutine(DataHolder.EffectsHandler.ShakeCamera(0.5f, 0.3f));
            TakeDamage(virus.GiveDamage());
            
            if (HealthPoint<=0)
            {
                DataHolder.Labaratory.Culdorn.RemoveRecepy();
                PauseGame.SetCanvasActiveEndOfGame(false);
            }
        }
    }

    public void TakeDamage(float Damage)
    {
        if (HealthPoint > 0)
        {
            HealthPoint -= Damage;
            DataHolder.UIHandler.RemoveHeart();
        }
      
        
    }

}
