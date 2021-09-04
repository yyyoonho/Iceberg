using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CubeMove : MonoBehaviour
{
    private float x;
    private float z;
    private Vector3 movingPoint;
    public Transform cube;

    private void Start()
    {
        StartCoroutine(RandomMove());
    }

    //3.5초마다 Enemy가 무작위로 움직일 수 있도록, 맵의 무작위 좌표에 이동할 곳 생성.
    IEnumerator RandomMove()
    {
        while(true)
        {
            yield return new WaitForSeconds(3.5f);
            x = Random.Range(-30.0f, 30.0f);
            z = Random.Range(-30.0f, 30.0f);
            movingPoint = new Vector3(x, 1, z);
            cube.position = movingPoint;
        }
    }
}
