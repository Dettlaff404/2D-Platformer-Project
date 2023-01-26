using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript thisGameManagerScript; //to access this script in other scripts

    public int maxHealth = 100; //maximum health value of the player
    public int currentHealth; //current health value of the player

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //resetting the health value of the player

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
    public void DealDamage(int amountOfDamage)
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
