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
