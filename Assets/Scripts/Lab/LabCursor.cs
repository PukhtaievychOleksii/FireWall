using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabCursor : MonoBehaviour
{
    public GameObject MagicEffect;
    public float EffectTime;
    public ParticleSystem Effect;
    public List<ParticleSystem> Effects;
    void Start()
    {
        //MagicEffect.SetActive(false);
         foreach(ParticleSystem effect in Effects)
         {
             ParticleSystem.EmissionModule em = effect.emission;
             em.enabled = false;

         }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMagicEffect()
    {
        if (gameObject.active == false) return;
        SetMagicEffect(true);
        StartCoroutine(StopMagicEffect());
    }

    private IEnumerator StopMagicEffect()
    {
        yield return new WaitForSeconds(EffectTime);
        SetMagicEffect(false);

    }

    public void SetMagicEffect(bool value)
    {
        foreach (ParticleSystem effect in Effects)
        {
            ParticleSystem.EmissionModule em = effect.emission;
            em.enabled = value;

        }
    }
}
