using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThachParticle : MonoBehaviour
{
    public ParticleSystem particle;
    private void OnParticleTrigger()
    {
        Debug.Log("OnParticleTrigger");
        
    }

}
