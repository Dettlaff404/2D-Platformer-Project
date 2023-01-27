using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        //assigning the text component to the score variable
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //setting the text of the UI to display the score value
        score.text = "Score: " + GameManagerScript.thisGameManagerScript.scoreValue;
    }
}
