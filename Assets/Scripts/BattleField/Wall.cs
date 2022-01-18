using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour , IDamageable
{
    public float HealthPoint = 2;
    [SerializeField]
    private Game Game;//must be set in Unity

    void Start()
    {
       /* alarm = GetComponentInChildren<Alarm>();
        alarm.OnAlarm += DataHolder.EffectsHandler.PlayAlarmEffects;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Virus virus = collision.GetComponent<Virus>();
        if (virus != null)
        {
            virus.Destroy();
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
