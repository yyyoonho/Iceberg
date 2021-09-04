
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

public class LivingEntity : MonoBehaviour
{
    public UnityEvent DieEvent;

    public int startingHealth;
    public int health;
    public bool dead;
    public Animator anim;

    //체력을 초기화합니다.
    protected virtual void Start()
    {
        health = startingHealth;
    }

    //공격을 받은 경우.
    public void TakeHit(int damage)
    {
        health -= damage;
        Debug.Log("Hit");
        if(health <=0&&!dead)
        {
            health = 0;
            Die();
            return;
        }
    }

    //체력을 회복한 경우.
    public void TakeHeal(int heal)
    {
        if(health>=100)
        {
            return;
        }
        else if(health<100)
        {
            if(health>=100)
            {
                health = 100;
            }
            Debug.Log("Heal");
            health += heal;
            return;
        }
    }

    //객체가 죽은 경우.
    protected void Die()
    {
        Debug.Log("죽었습니다..");
        dead = true;
        //유니티 이벤트만들기
        DieEvent.Invoke();
    }
}
