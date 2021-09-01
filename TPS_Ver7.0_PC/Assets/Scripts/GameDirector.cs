using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameDirector : MonoBehaviour
{
    public GameObject player;
    public EnemySpawnGenerator enemySpawnGenerator;
    private float timeLeft = 1.0f;
    private float nextTime = 0.0f;
    private bool enemyState = false;
    private bool playerState = true;

    private void Start()
    {
        // 초기 점수를 0점으로 초기화한다.
        UIManager.Instance.UpdateScoreText(0);

    }
    
    private void Update()
    {
        if(Time.time>nextTime && enemyState==true && playerState ==true)
        {
            nextTime = Time.time + timeLeft;
            TakeDamageRegulary();
        }

        if(enemyState == false)
        {
            enemyState = true;
            enemySpawnGenerator.RespawnEnemySpot();
        }
    }

    void TakeDamageRegulary()
    {
        //게임 시작과 동시에 플레이어는 매초 1의 피해를 받습니다.
        player.GetComponent<Player>().TakeHit(1);
        UIManager.Instance.UpdateHp(player.GetComponent<Player>().health);
        if(player.GetComponent<Player>().health<=0)
        {
            playerState = false;
            player.GetComponent<Player>().DeadState();
        }
    }

    public void ChaneEnemyStateToDead()
    {
        enemyState = false;
    }

}
