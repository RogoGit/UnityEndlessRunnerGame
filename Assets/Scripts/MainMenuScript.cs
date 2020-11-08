using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public Text highscoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        highscoreLabel.text = "Current highscore: " + ((int)PlayerPrefs.GetFloat("highscore")).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

}
