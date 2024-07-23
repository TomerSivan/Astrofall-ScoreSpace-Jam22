using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject deathScreen;


    [SerializeField] Image mutedIcon;





    [SerializeField] Sprite mutedImage;
    [SerializeField] Sprite unmutedImage;

    [SerializeField] bool isMuted;

    private bool dead;

    private float counter;



    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;


    }
    public void Dead()
    {
        dead = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Home(int SceneID)
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1;
        SceneManager.LoadScene(SceneID);
    }
    public void MuteUnmute()
    {
        if(isMuted)
        {
            isMuted = false;
            mutedIcon.sprite = mutedImage;

            AudioListener.volume = 1;
        }
        else
        {
            isMuted = true;
            mutedIcon.sprite = unmutedImage;
            AudioListener.volume = 0;

        }

    }

    void Start()
    {
        pauseMenu.SetActive(false);
        deathScreen.SetActive(false);
        isMuted = false;
        dead = false;
        counter = 0;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            counter += Time.deltaTime;
            if (counter > 0.6f)
            {
                deathScreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
