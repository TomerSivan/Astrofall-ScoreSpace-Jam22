using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCounter : MonoBehaviour
{
    public static int score;
    public Text scoreTxt;



    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score: " + score;
    }

    
}
