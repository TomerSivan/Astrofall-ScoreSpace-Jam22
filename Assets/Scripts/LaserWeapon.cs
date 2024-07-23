using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 20;
    [SerializeField] private int damage = 500;

    public Transform laserFirePoint;
    public LineRenderer _lineRenderer;
    Transform _transform;
    Animator animator;

    public GameObject impactEffect;


    public float timeRemaining;




    private void Awake()
    {
        
        _transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        animator.SetBool("IsCharging", false);


        timeRemaining = 5f;

        
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(_transform.position, _transform.up))
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(laserFirePoint.position, _transform.up);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                PlayerController player = hit.collider.GetComponent<PlayerController>();

                SatelliteEnemy enemy = hit.collider.GetComponent<SatelliteEnemy>();

                LaserEnemy enemy2 = hit.collider.GetComponent<LaserEnemy>();

                if (player)
                {
                    Draw2DRay(laserFirePoint.position, new Vector2(laserFirePoint.position.x, hit.point.y));
                    Instantiate(impactEffect, hit.point, transform.rotation);
                }
                    
                else
                    Draw2DRay(laserFirePoint.position, new Vector2(laserFirePoint.position.x, defDistanceRay));



                if (player != null)
                    player.TakeDamage(damage);
            }

            

            


            
            
        }
        else
        {
            Draw2DRay(laserFirePoint.position, new Vector2(laserFirePoint.position.x, defDistanceRay));
        }
    }
    void Draw2DRay(Vector2 startPos, Vector2 endPos) 
    {
        
        _lineRenderer.SetPosition(0, startPos);
        _lineRenderer.SetPosition(1, endPos);
        
    }

    void ClearLaser()
    {
        if (_lineRenderer.positionCount!=0)
            _lineRenderer.positionCount = 0;
    }
    
    
    
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsCharging", true);

        if (timeRemaining <= 0)
        {
            _lineRenderer.positionCount = 2;
            ShootLaser();

            if (timeRemaining <= -4f)
                timeRemaining = 20f;
        }

        if (timeRemaining < 20f && timeRemaining > 19f)
        {
            ClearLaser();
        }
        timeRemaining -= Time.deltaTime;
    }
}
