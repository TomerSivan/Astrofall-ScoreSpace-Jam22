using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliEnemy : MonoBehaviour
{
    public int health = 300;

    public GameObject deathEffect;

    public float speed = 0.25f;

    public Rigidbody2D rb;


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        ScoreCounter.score += 2;
        Destroy(gameObject);
    }
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
