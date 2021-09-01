using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{
    public ParticleSystem PR; //Particle Route
    public ParticleSystem PH; //Particle Hit
    
    private void Start()
    {
        PR.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        PR.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        if (collision.gameObject.tag =="Enemy")
        {
            PH.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}
