using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 200;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    void Start()
    {

        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        SatelliteEnemy enemy = hitInfo.GetComponent<SatelliteEnemy>();
        LaserEnemy enemy2 = hitInfo.GetComponent<LaserEnemy>();
        HeliEnemy enemy3 = hitInfo.GetComponent<HeliEnemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
        }
        if (enemy3 != null)
        {
            enemy3.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
    }
}