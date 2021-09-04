using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip throwBall;
    public Animator animator;
    public GameObject snowGenerator;
    public float timeBetweenShot = 1f;
    private float lastShotTime;

    public void attack()
    {
        // attack입력이 될 시, snowGenerator에서 눈덩이를 소환하여 던집니다. 
        // 눈덩이를 던지는 Player 애니메이션을 재생합니다.
        snowGenerator.GetComponent<SnowGenerator>().ShootSnow();
        aud.PlayOneShot(throwBall);
    }

    public void Fire()
    {
        // 공격 간 일정 텀을 두어, 비정상적인 연속공격이 불가능하게 합니다.
        if (Time.time > lastShotTime + timeBetweenShot)
        {
            //공격 휘두르기모션
            animator.SetTrigger("attackMotion"); 
            lastShotTime = Time.time;
        }
    }
}


