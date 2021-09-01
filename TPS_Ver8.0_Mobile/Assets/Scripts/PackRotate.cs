using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackRotate : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0 * Time.deltaTime, 60 * Time.deltaTime, 0 * Time.deltaTime);
    }
}
