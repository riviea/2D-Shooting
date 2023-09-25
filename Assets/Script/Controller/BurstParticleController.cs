using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstParticleController : MonoBehaviour
{
    [SerializeField] private bool createDustOnMalk = true;
    [SerializeField] private ParticleSystem dustParticleSystem;

    public void CreateDustParticles()
    {
        if(createDustOnMalk)
        {
            dustParticleSystem.Stop();
            dustParticleSystem.Play();
        }
    }
}
