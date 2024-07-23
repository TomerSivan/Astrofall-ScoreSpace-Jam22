using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;

    private float cooldownBullet;
    private float cooldownMissile;

    private bool canShootBullet;
    private bool canShootMissile;

    public float holdTime = 0;

    public Slider slider;
    public ParticleSystem chargingParticle;

    

    public void IncremenntChargeUpSlider(float charge)
    {
        
        slider.value = charge;

        

        
        if(!chargingParticle.isPlaying)
        {
            chargingParticle.Play();
        }
    }




    void Start()
    {
        slider.value = 0;
        canShootBullet = true;

        cooldownBullet = 0;
        cooldownMissile = 0;

        


    }

    void Update()
    {


        cooldownBullet += Time.deltaTime;
        cooldownMissile += Time.deltaTime;


        if (cooldownBullet >= 0.5f && Time.timeScale != 0)
        {
            cooldownBullet = 0;
            canShootBullet=true;
        }

        if (cooldownMissile >= 2f)
        {
            cooldownMissile = 0;
            canShootMissile = true;
        }



        if (Input.GetButton("Fire1") && canShootMissile)
        {
            holdTime += Time.deltaTime;
            if (holdTime >= 0.2f)
            {
                IncremenntChargeUpSlider(holdTime / 1.8f);
            }
            
        }



        if (canShootBullet && Input.GetButtonUp("Fire1") && holdTime < 2)
        {
            Shoot();
            canShootBullet = false;
            holdTime = 0;
            slider.value = 0;

            chargingParticle.Pause();
            chargingParticle.Clear();
        }

        if (holdTime >= 2 && Input.GetButtonUp("Fire1"))
        {
            ShootMissile();
            holdTime = 0;
            canShootMissile = false;
            slider.value = 0;

            chargingParticle.Pause();
            chargingParticle.Clear();
        }




        
        
        

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootMissile()
    {
        Instantiate(missilePrefab, new Vector3(firePoint.position.x,firePoint.position.y-0.2f,0), firePoint.rotation);
    }
}
