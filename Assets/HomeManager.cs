using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HomeManager : MonoBehaviour
{
    private float waitTime;
    private bool pressed;

    void Start()
    {
        waitTime = 0;
        pressed = false;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.anyKey)
        {
            pressed = true;
            
        }
        if (pressed)
        {
            waitTime += Time.deltaTime;
            if (waitTime >= 1f)
            {
                SceneManager.LoadScene(1);
                pressed = false;
            }
        }
    }
}
