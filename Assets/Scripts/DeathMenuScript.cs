using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{
    public Text scoreText;
    public Image background;

    // show death menu
    public void toggleDeathMenu(float finalScore)
    {
        gameObject.SetActive(true);
        scoreText.text = "End of the road!\n Your score is " + ((int)finalScore).ToString();
    }

    // restart game
    public void playAgain()
    {   
        // reboot the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Game scene
    }

    // return to main menu
    public void backToMenu()
    {
        // will be later
    }

    // Start is called before the first frame update
    void Start()
    {
        // at first death menu is not active
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
