using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public int coinScore = 50; //coin score value
   
    [SerializeField] private AudioSource coinSound; //sound to play while picking up the coin 


    //function to trigger if something collides with the gameObject 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if it collides with the player
        if (collision.CompareTag("Player") && (this.GetComponent<SpriteRenderer>().enabled == true))
        {
            //add coinscore value to the player score, play the coin pickup sound and destroy the game object
            GameManagerScript.thisGameManagerScript.scoreValue += coinScore;
            coinSound.Play();
            this.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject,1f);
        }
    }
}
