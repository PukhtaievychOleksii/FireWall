using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour , IDamageable
{
    public float HealthPoint = 2;
    [SerializeField]
    private Game Game;//must be set in Unity
    private AudioSource audioSource;
    public SoundEffectUpdater soundeffectUpdater;

    void Start()
    {
        /* alarm = GetComponentInChildren<Alarm>();
         alarm.OnAlarm += DataHolder.EffectsHandler.PlayAlarmEffects;*/
        audioSource = GetComponent<AudioSource>();
        soundeffectUpdater.UpdateEffect(audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseGame.GameIsPoused)
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
        else Game.Match.OnDefeated?.Invoke();
        
    }
}
