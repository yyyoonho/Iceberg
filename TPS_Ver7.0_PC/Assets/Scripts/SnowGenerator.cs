using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour
{
    public Transform spawnPosition;
    public Rigidbody snowPrefab;
    public void ShootSnow()
    {
        Rigidbody snow = Instantiate(snowPrefab, spawnPosition.position, spawnPosition.rotation);
        snow.AddForce(spawnPosition.forward * 1500);
        Destroy(snow.gameObject, 2f);
    }

}
