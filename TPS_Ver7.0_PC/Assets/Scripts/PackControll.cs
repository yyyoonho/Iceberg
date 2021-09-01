using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackControll : MonoBehaviour
{
    public float time;

    private void Start()
    {
        Invoke("DestroyObject", time);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
