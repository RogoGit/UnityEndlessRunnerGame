﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{

    // user score variables
    private float userScore = 0.0f;
    public Text uiTextScore; //text field for displaying score

    // difficulty level
    private int gameSpeedLevel = 1;
    private int maxGameSpeedLevel = 10;
    private int scoreToIncreaseSpeed = 10; // when game becomes faster
    // increasing game speed
    void speedUp()
    {
        if (gameSpeedLevel >= maxGameSpeedLevel) 
            return;

        gameSpeedLevel++;
        scoreToIncreaseSpeed *= 2;
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        if (userScore >= scoreToIncreaseSpeed)
        {
            speedUp();
        }

        // updating current score
        userScore += Time.deltaTime * gameSpeedLevel;
        // updating current score in UI
        uiTextScore.text =  ((int)userScore).ToString();   

        // increase player speed
        GetComponent<PlayerMovings>().setSpeed(gameSpeedLevel);

    }
}
