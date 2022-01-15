using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsHandler : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip AlarmSound;
    public GameObject realAlarm;
    private Camera Camera;

    void Start()
    {
        DataHolder.SetEffectsHandler(this);
        AudioSource = GetComponent<AudioSource>();
        realAlarm = GameObject.Find("AlarmLight");
        Camera = GetComponent<Camera>();

    }

    public void StartAlarmEffects()
    {
        realAlarm.GetComponent<Animator>().SetTrigger("on");

        if(AlarmSound != null)
        {
            AudioSource.clip = AlarmSound;
            AudioSource.Play();
        }
    }

    public void StopAlarmEffeects()
    {
        realAlarm.GetComponent<Animator>().SetTrigger("off");
        AudioSource.Stop();
    }

    public IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 initialPos = Camera.gameObject.transform.position;
        float elapsed = 0f;
        while ( elapsed < duration)
        {
            float x = Random.Range(-0.2f, 0.2f) * magnitude;
            float y = Random.Range(-0.2f, 0.2f) * magnitude;
            transform.localPosition = new Vector3(initialPos.x + x,initialPos.y + y, initialPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = initialPos;
    }

}
