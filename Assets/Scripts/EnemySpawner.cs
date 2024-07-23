using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemySat;

    public GameObject enemyLas;

    public GameObject enemyHeli;





    private bool mode1 = false;
    private bool mode2 = false;
    private bool mode3 = false;
    private bool mode4 = false;




    public GameObject gameManager;

    private GameScript gameScript;

    private float altitude;

    private float intervalSat;

    private float intervalLas;

    private float intervalHeli;




    private int iPosition;

    private float[] positions = {-3f, -1.5f, 0, 1.5f, 3f};

    private int laserXi;


    


    // Start is called before the first frame update
    void Start()
    {
        mode1 = true;
        gameScript = gameManager.GetComponent<GameScript>();


        //StartCoroutine(spawnEnemySat(satelliteInterval, satelliteEnemy));
        StartCoroutine(spawnEnemySat());

        StartCoroutine(spawnEnemyLas());

        StartCoroutine(spawnEnemyHeli());

        intervalHeli = 5f;
        intervalSat = 4f;
        intervalLas = 10f;
    }


    void Update()
    {
        
        altitude = gameScript.getAlt();

        

        if (altitude < 75000f && altitude>74000)
        {
            mode2 = true;
            mode1 = false;

            intervalLas = 10f;
            intervalSat = 4f;
            
        }
        if (altitude < 50000f && altitude>49000f)
        {
            mode3 = true;
            mode2 = false;
            intervalHeli = 5f;
        }

        if (altitude <25000f && altitude> 24000f)
        {
            mode4 = true;
            mode3 = false;
            intervalHeli = 5f;
            intervalLas = 8f;
        }
        if (altitude <4000f )
        {
            mode4 = false;

            
        }
            
    }

    //private IEnumerator spawnEnemySat(float intervalSat, GameObject enemySat)
    //{
    //    if (mode1 == true || mode2 == true)
    //    {
    //        yield return new WaitForSeconds(intervalSat);
    //        GameObject newEnemy = Instantiate(enemySat, new Vector3(positions[getXi()], -5f, 0), Quaternion.identity);
    //        StartCoroutine(spawnEnemySat(intervalSat, enemySat));
    //    }

    //}

    private IEnumerator spawnEnemyHeli()
    {
        
        
        yield return new WaitForSeconds(intervalHeli);

        if (mode3 && intervalHeli > 1.2f)
        {

             intervalHeli = intervalHeli - 0.1f;
             GameObject newEnemy = Instantiate(enemyHeli, new Vector3(getX(), -5f, 0), Quaternion.identity);
        }
        if (mode4 && intervalHeli > 1.5f)
        {
            intervalHeli = intervalHeli - 0.1f;
            GameObject newEnemy = Instantiate(enemyHeli, new Vector3(getX(), -5f, 0), Quaternion.identity);
        }
        StartCoroutine(spawnEnemyHeli());







    }

    private IEnumerator spawnEnemySat()
    {
        if (mode1 == true || mode2 == true)
        {
            yield return new WaitForSeconds(intervalSat);
            if (mode1 && intervalSat > 0.8f)
            {
                
                intervalSat = intervalSat - 0.1f;
            }
            if (mode2 && intervalSat > 1f)
            {
                intervalSat = intervalSat - 0.1f;
            }
            GameObject newEnemy = Instantiate(enemySat, new Vector3(getX(), -5f, 0), Quaternion.identity) ;
            StartCoroutine(spawnEnemySat());
        }

    }

    private IEnumerator spawnEnemyLas()
    {
        
        yield return new WaitForSeconds(intervalLas);
        
        if (mode2)
        {
            intervalLas = intervalLas - 0.55f;
            laserXi = getXiLaser();
            GameObject newEnemy = Instantiate(enemyLas, new Vector3(positions[laserXi], -5f, 0), Quaternion.identity);


        }
        if (mode4)
        {
            intervalLas = intervalLas - 0.35f;
            laserXi = getXiLaser();
            GameObject newEnemy = Instantiate(enemyLas, new Vector3(positions[laserXi], -5f, 0), Quaternion.identity);
        }
            
        

        
            
        

        
        StartCoroutine(spawnEnemyLas());
    }

    int getXiLaser()
    {
        iPosition = Random.Range(0, 5);
        
        return iPosition;
    }

    float getX()
    {
        iPosition = Random.Range(0, 5);

        

        

        return positions[iPosition];
    }
}
