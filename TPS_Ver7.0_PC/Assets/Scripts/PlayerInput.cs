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
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > lastShotTime + timeBetweenShot)
            {
                animator.SetTrigger("attackMotion"); //공격 휘두르기모션
                lastShotTime = Time.time;
            }  
        }
    }
    public void attack()
    {
        //애니메이션 이벤트 실행
        snowGenerator.GetComponent<SnowGenerator>().ShootSnow();
        aud.PlayOneShot(throwBall);
    }
}


