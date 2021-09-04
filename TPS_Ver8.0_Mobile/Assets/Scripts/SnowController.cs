using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{
    public ParticleSystem PR; //Particle Route
    public ParticleSystem PH; //Particle Hit
    
    // 눈덩이 파티클효과를 시작합니다.
    private void Start()
    {
        PR.Play();
    }

    // 눈덩이가 Enemy에 맞았을 경우, Hit 파티클효과를 재생합니다. 이후, 눈덩이를 destroy합니다.
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
