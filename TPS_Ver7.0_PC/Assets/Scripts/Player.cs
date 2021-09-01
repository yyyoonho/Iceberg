using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : LivingEntity
{
    public AudioSource aud;
    public AudioClip antiPackSound;
    public AudioClip healPackSound;
    public AudioClip deadSound;

    public int antipackDamage;
    public int healpackDamage;

    public enum State
    {
       idle, hitPack, healPack, inArea
    };
    public State playerState  = State.idle;

    protected override void Start()
    {
        base.Start();
        StartCoroutine("CheckState");
    }

    private void OnTriggerStay(Collider other) //해당 Area에 있으면 피해를 받거나, 회복합니다.
    {
        if(other.tag =="HealPack")
        {
            Debug.Log("[힐팩] 경계안에서 초당 3씩 회복합니다!");
            playerState = State.healPack;
        }
        if(other.tag =="AntiPack")
        {
            Debug.Log("[안티팩] 경계안에서 초당 5씩 공격받습니다!");
            playerState = State.hitPack;
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        playerState = State.idle;
    }

    IEnumerator CheckState()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            if(playerState == State.hitPack) //초당 10의 데미지를받고, 20의 스코어가 감소합니다.
            {
                this.transform.Translate(Vector3.up * 2);
                UIManager.Instance.UpdateHp(health);
                aud.PlayOneShot(antiPackSound);
                base.TakeHit(antipackDamage);
                UIManager.Instance.UpdateScoreText(-antipackDamage);
                playerState = State.idle;
                if (dead == true)
                {
                    break;
                }
            }
            else if(playerState == State.healPack) //초당 10의 체력을 회복합니다.
            {
                UIManager.Instance.UpdateHp(health);
                aud.volume = 1f;
                aud.PlayOneShot(healPackSound);
                base.TakeHeal(healpackDamage);
                UIManager.Instance.UpdateScoreText(healpackDamage);
                playerState = State.idle;
            }
        }
        DeadState();
    }

    private void DestroyObject()
    {
        SceneManager.LoadScene("EndScene");
        //Destroy(gameObject);
    }

    public void DeadState()
    {
        gameObject.GetComponent<PlayerInput>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        anim.SetTrigger("IsDead2");
        aud.PlayOneShot(deadSound);
        Invoke("DestroyObject", 5.0f);
    }
}
