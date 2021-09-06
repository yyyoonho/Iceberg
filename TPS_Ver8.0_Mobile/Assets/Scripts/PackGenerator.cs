using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PackGenerator : MonoBehaviour
{
    public float instantTime;

    public GameObject antiPackPrefab;
    public GameObject healPackPrefab;
    public Transform spawner;

    private bool dead = false;
    private void Start()
    {
        StartCoroutine(InstantiateAnitPack());
    }
    private void Update()
    {
        if(dead)
        {
            StopCoroutine(InstantiateAnitPack());
        }
    }

    //AntiPack을 인스턴트 시킵니다.
    IEnumerator InstantiateAnitPack()
    {
        while(!dead)
        {
            if(dead==true)
            {
                StopCoroutine(InstantiateAnitPack());
            }
            Instantiate(antiPackPrefab,
                new Vector3(spawner.position.x, spawner.position.y, spawner.position.z), spawner.rotation);
            yield return new WaitForSeconds(instantTime);
        }
    }

    //HealPack을 인스턴트 시킵니다.
    public void InstantiateHealPack()
    {
        Instantiate(healPackPrefab, 
            new Vector3(spawner.position.x, spawner.position.y+1, spawner.position.z+2), spawner.rotation);
    }

    public void ChangeStateDead()
    {
        dead = true;
    }
}
