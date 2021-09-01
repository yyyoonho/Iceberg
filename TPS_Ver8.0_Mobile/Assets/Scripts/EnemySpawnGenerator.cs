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
        childrenSpot = this.gameObject.GetComponentsInChildren<Transform>(); //자식 스팟들을 가지고옵니다.
    }
    public void RespawnEnemySpot()
    {
        index = Random.Range(1, 8);
        Instantiate(enemyPrefab, childrenSpot[index].transform.position, childrenSpot[index].transform.rotation);
    }
    
}
