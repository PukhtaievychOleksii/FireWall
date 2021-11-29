using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private SpriteRenderer renderer;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
     
    }

    public void OnAlarm()
    {
        gameObject.SetActive(true);
        renderer.enabled = true;
        DataHolder.EffectsHandler.StartAlarmEffects();
    }

    public void StopAlarm()
    {
        gameObject.SetActive(false);
        renderer.enabled = false;
        DataHolder.EffectsHandler.StopAlarmEffeects();
    }
   


}
