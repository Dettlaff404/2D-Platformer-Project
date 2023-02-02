using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlagController : MonoBehaviour
{
    //function to trigger when something enters the flag collider 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the entered gameobject is the player
        if (collision.CompareTag("Player"))
        {
            //show the you win UI screen
            GameManagerScript.thisGameManagerScript.YouWin();
        }
    }
}
