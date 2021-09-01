using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum CurrentState { idle, trace, attack, dead};
    public CurrentState curState = CurrentState.idle;
    public GameDirector gameDirector;

    private Transform _transform;
    private Transform playerTransform; //이후에 랜덤상자로 변경할 것!
    private NavMeshAgent nvAgent;
    private Animator anim;

    //추적 사정거리
    public float traceDist = 200.0f;

    //사망여부
    private bool isDead = false;

    private void Start()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("cube").GetComponent<Transform>(); //큐브의 위치로 바꾸기!
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();

        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
    }

    IEnumerator CheckState()
    {
        while(!isDead)
        {
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Distance(playerTransform.position, _transform.position); //플레이어 -> 큐브로 바꾸기

            if(dist<=traceDist)
            {
                curState = CurrentState.trace;
            }

            else
            {
                curState = CurrentState.idle;
            }
        }
        if(isDead) //죽었을때
        {
            Invoke("DestroyObject", 4.3f);
            anim.SetTrigger("IsDead");
            StopCoroutine(CheckState());
        }
    }

    IEnumerator CheckStateForAction()
    {
        while(!isDead)
        {
            switch(curState)
            {
                case CurrentState.idle:
                    nvAgent.Stop();
                    anim.SetBool("isMoving", false);
                    
                    break;
                case CurrentState.trace:
                    nvAgent.destination = playerTransform.position;
                    nvAgent.Resume();
                    anim.SetBool("isMoving", true);
                    break;
                case CurrentState.attack:
                    //어택 애니메이션 재생
                    break;
            }
            yield return null;
        }
        if(isDead)
        {
            nvAgent.Stop();
        }
    }

    private void DestroyObject()
    {
        gameDirector.ChaneEnemyStateToDead();
        Destroy(gameObject);

    }

    public void changeStateDead()
    {
        isDead = true;
    }
}
