using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private float edges = 3f;
    private float move = 1.5f;
    public int health = 100;

    [SerializeField] GameObject pauseButton;

    private PauseMenu pauseMenu;

    public GameObject deathEffect;



    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        pauseMenu = pauseButton.GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && transform.position.x < edges)
            {
                transform.position = new Vector2(transform.position.x + move, transform.position.y);
            }

            if ((Input.GetKeyDown("a") || Input.GetKeyDown("left")) && transform.position.x > -edges)
            {
                transform.position = new Vector2(transform.position.x - move, transform.position.y);
            }
        }
        
    }

    
    void OnTriggerEnter2D(Collider2D collider)
    {
        SatelliteEnemy enemy = collider.GetComponent<SatelliteEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(1000);
            Destroy(gameObject);
        }
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {

        pauseMenu.Dead();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
