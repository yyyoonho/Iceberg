
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
    protected virtual void Start()
    {
        health = startingHealth;
    }
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
    protected void Die()
    {
        Debug.Log("죽었습니다..");
        dead = true;
        //유니티 이벤트만들기
        DieEvent.Invoke();
    }
}
