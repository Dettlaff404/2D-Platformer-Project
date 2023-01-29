using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript thisGameManagerScript; //to access this script in other scripts

    public float maxHealth = 100; //maximum health value of the player
    public float currentHealth; //current health value of the player
    public GameObject player; //player gameObject

    public int scoreValue; //to be referenced to the player score value

    // Awake is called before the start of the game
    void Awake()
    {
        //assigning the game manager script to be referenced in other scripts if its not assigned earlier
        if (thisGameManagerScript == null)
        {
            thisGameManagerScript = this;
        }

        //if the player had chosem to load previos game data from a menu option before, loading saved data as current data
        //data which loaded here are player health, score, and position
        if (PlayerPrefs.GetInt("LoadTheData") == 1)
        {
            PlayerPrefs.SetInt("LoadTheData", 0);
            PlayerPrefs.Save();
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;

            pX = PlayerPrefs.GetFloat("PlayerX");
            pY = PlayerPrefs.GetFloat("PlayerY");
            player.transform.position = new Vector2(pX, pY);

            currentHealth = PlayerPrefs.GetFloat("Health");
            scoreValue = PlayerPrefs.GetInt("Score");
        }
        else
        {
            currentHealth = maxHealth; //resetting the health value of the player
            scoreValue = 0; //resetting the player score value
        }

        //starting the inputs,functions and animations of the game if its been paused on a previous menu
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

    }

    // Start is called before the Update of the first frame of the game
    private void Start()
    {

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
