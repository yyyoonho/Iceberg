using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int index; //Enemy가 소환될 리스폰스팟 번호. (1~7)
    private Transform[] childrenSpot;

    private void Start()
    {
        childrenSpot = this.gameObject.GetComponentsInChildren<Transform>();
    }

    // Enemy가 생성될 수 있는 spot을 맵 위에 무작위로 생성합니다.
    public void RespawnEnemySpot()
    {
        index = Random.Range(1, 8);
        Instantiate(enemyPrefab, childrenSpot[index].transform.position, childrenSpot[index].transform.rotation);
    }
    
}
