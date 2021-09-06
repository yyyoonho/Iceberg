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
    private Transform playerTransform;
    private NavMeshAgent nvAgent;
    private Animator anim;

    //Enemy가 해당 사정거리안에 Player가 접근 시 추격.
    public float traceDist = 200.0f;

    //사망여부 확인
    private bool isDead = false;

    private void Start()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("cube").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();

        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
    }

    IEnumerator CheckState()
    {
        // Enemy가 살아있다면, 플레이어와의 거리에 따라 trace모드, 
        // idle 모드로 전환합니다.
        while(!isDead)
        {
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Distance(playerTransform.position, _transform.position);

            if(dist<=traceDist)
            {
                curState = CurrentState.trace;
            }

            else
            {
                curState = CurrentState.idle;
            }
        }
        // Enemy가 죽었을 경우, 상태체크를 stop하고 IsDead 애니메이션 재생, 
        // 이후 오브젝트 destroy 합니다.
        if (isDead)
        {
            Invoke("DestroyObject", 4.3f);
            anim.SetTrigger("IsDead");
            StopCoroutine(CheckState());
        }
    }

    // 상태에 따라 애니메이션을 변경합니다.
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
                    //어택옵션 추가 시, 애니메이션 재생
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
