using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{

    private float userScore = 0.0f;
    public Text uiTextScore; //text field for displaying score

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // updating current score
        userScore += Time.deltaTime;
        // updating current score in UI
        uiTextScore.text =  ((int)userScore).ToString();   
    }
}
