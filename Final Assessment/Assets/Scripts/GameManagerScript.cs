using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript thisGameManagerScript; //to access this script in other scripts

    public float maxHealth = 100; //maximum health value of the player
    public float currentHealth; //current health value of the player

    public int scoreValue; //to be referenced to the player score value

    // Awake is called before the start of the game
    void Awake()
    {
        currentHealth = maxHealth; //resetting the health value of the player
        scoreValue = 0; //resetting the player score value

        //assigning the game manager script to be referenced in other scripts if its not assigned earlier
        if (thisGameManagerScript == null)
        {
            thisGameManagerScript = this;
        }

        
    }

    // Start is called before the Update of the first frame of the game
    private void Start()
    {
        Time.timeScale = 1; //resetting the timescale of the game
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            PlayerController.playerControllerScript.PlayerDead();
        }
    }

}
