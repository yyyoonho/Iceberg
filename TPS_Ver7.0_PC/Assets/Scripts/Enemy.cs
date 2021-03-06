using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : LivingEntity
{
    public AudioSource aud;
    public AudioClip hitBySnow;
    public int snowDamage;
    private GameObject enemyHp;


    protected override void Start()
    {
        base.Start();
        enemyHp = GameObject.Find("EnemyHp");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("snow"))
        {
            Debug.Log("눈덩이에 맞았습니다!");
            aud.PlayOneShot(hitBySnow);
            UIManager.Instance.UpdateScoreText(100);
            base.TakeHit(snowDamage); //눈덩이를 맞을때마다 20씩 hp가 감소합니다.
            enemyHp.gameObject.GetComponent<Slider>().value += -snowDamage; //머리위 UI로 enemy의 현재 체력을 표시합니다.
        }
    }

}
