using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript thisGameManagerScript; //to access this script in other scripts

    public float maxHealth = 100; //maximum health value of the player
    public float currentHealth; //current health value of the player

    public int scoreValue; //to be referenced to the player score value

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }

    //function to deal damage to the player
    public void DealDamage(float amountOfDamage)
    {
        //reducing the current health value of the player by the amount of damage recieved
        currentHealth = currentHealth - amountOfDamage;

        //making the lowest posible number that the current value could have 0
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
}
