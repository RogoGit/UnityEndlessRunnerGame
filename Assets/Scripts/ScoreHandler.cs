using System.Collections;
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

    private bool isPlayerDead = false;

    // death menu
    public DeathMenuScript deathMenu;

    // increasing game speed
    void speedUp()
    {
        if (gameSpeedLevel >= maxGameSpeedLevel) 
            return;

        gameSpeedLevel++;
        scoreToIncreaseSpeed *= 2;
    }

    public void setGameSpeedLevel(int speed) {
        gameSpeedLevel = speed;
    }

    public int getGameSpeedLevel() {
        return gameSpeedLevel;
    }

    // on player death action
    public void onDeath()
    {
        isPlayerDead = true;
        // save user score if it's a highscore
        if (PlayerPrefs.GetFloat("highscore") < userScore)
        {
            PlayerPrefs.SetFloat("highscore", userScore);
            PlayerPrefs.Save();
        }
        // show death menu
        deathMenu.toggleDeathMenu(userScore);
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerDead) return;

        if (!GetComponent<PlayerMovings>().getIsOnWater()) {
            if (userScore >= scoreToIncreaseSpeed)
            {
                speedUp();
            }  

            // increase player speed
            GetComponent<PlayerMovings>().setSpeed(gameSpeedLevel);
        }

        // updating current score
        userScore += Time.deltaTime * gameSpeedLevel;
        // updating current score in UI
        uiTextScore.text =  ((int)userScore).ToString(); 

    }
}
