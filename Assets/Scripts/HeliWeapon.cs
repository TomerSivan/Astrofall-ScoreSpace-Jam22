using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float timeRemaining;

    private int numberOfShots;

    private float timeBetweenShots;

    private bool timeBetweenValid;

    void Start()
    {
        timeRemaining = 4f;
        numberOfShots = 0;
        
        timeBetweenShots = 0;
    }

    void Update()
    {
        if (timeBetweenShots <= 0)
        {
            timeBetweenValid = true;
            timeBetweenShots = 0;
        }
        else
        {
            timeBetweenValid = false;
        }
        if (timeRemaining <= 0 && numberOfShots != 3 && timeBetweenValid)
        {
            Shoot();
            numberOfShots++;

            timeBetweenShots = 0.5f;
            
        }
        
        if (numberOfShots == 3)
        {
            numberOfShots=0;
            timeRemaining = Random.Range(5.5f, 7f);
        }
            
        timeBetweenShots -= Time.deltaTime;
        timeRemaining -= Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }
}
