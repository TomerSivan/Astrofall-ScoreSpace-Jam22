using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 100;
    public Rigidbody2D rb;
    public GameObject impactEffect;


    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();

        SatelliteEnemy enemy1 = hitInfo.GetComponent<SatelliteEnemy>();
        LaserEnemy enemy2 = hitInfo.GetComponent<LaserEnemy>();
        HeliEnemy enemy3 = hitInfo.GetComponent<HeliEnemy>();

        if (enemy1 == null && enemy2 == null && enemy3 == null)
        {
            if (player != null)
            {
                player.TakeDamage(damage);
                
            }
            Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }


        
        
    }
}
