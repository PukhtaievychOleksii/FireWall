using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour , IDamageable
{
    public float HealthPoint = 2;
    public AlarmZone alarm;
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
            TakeDamage(virus.GiveDamage());
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
