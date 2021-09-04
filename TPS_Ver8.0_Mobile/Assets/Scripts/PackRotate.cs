using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackRotate : MonoBehaviour
{
    // Enemy가 생성한 Pack을 회전시킵니다.
    void Update()
    {
        transform.Rotate(0 * Time.deltaTime, 60 * Time.deltaTime, 0 * Time.deltaTime);
    }
}
