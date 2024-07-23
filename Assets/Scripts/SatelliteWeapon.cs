using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float timeRemaining;

    void Start()
    {
        timeRemaining = 0.6f;
    }



    void Update()
    {
        if (timeRemaining <= 0)
        {
            Shoot();
            timeRemaining = Random.Range(2.5f, 5.5f);
        }
        timeRemaining -= Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
