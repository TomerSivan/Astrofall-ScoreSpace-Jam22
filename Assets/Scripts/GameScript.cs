using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class GameScript : MonoBehaviour
{
    public Text altitudeTxt;



    private float time;

    public float altitude;

    private float fallingSpeed = 333.333f;

    private bool paused;

    [SerializeField] GameObject background;

    public GameObject pauseButton;

    private Animator bgAnimator;

    private PauseMenu pauseMenu;






    //private bool paused;

    void Start()
    {
        pauseMenu = pauseButton.GetComponent<PauseMenu>();

        bgAnimator = background.GetComponent<Animator>();

        time = 0;
        altitude = 100000;

        paused = false;


    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //altitude = altitudeStart - 0.5f * 9.8f * Mathf.Pow(2, time);
        altitude -= fallingSpeed*Time.deltaTime;

        updateAltitude(altitude);

        bgAnimator.SetFloat("Alt", altitude);


            if (Input.GetButtonDown("Cancel"))
            {
                if (paused == false)
                {
                    paused = true;
                    pauseMenu.Pause();
                }
                else
                {
                    paused = false;
                    pauseMenu.Resume();
                }
            }

    }

    void updateAltitude (float currentAltitude)
    {
        currentAltitude = Mathf.FloorToInt(currentAltitude);

        altitudeTxt.text = string.Format("Altitude: {0}M", currentAltitude);
    }

    public float getAlt()
    {
        return altitude;
    }
}
