using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public float kunaiSpeed; //speed in which kunai will be moving 
    public float kunaiDamage; //kunai damage amount

    [SerializeField] private AudioSource weaponHitSound; //kunai hitting sound 

    // Start is called before the first frame update
    void Start()
    {
        //add velocity to the kunai in the direction which the kunai is facing at the start of the game object
        if (this.GetComponent<SpriteRenderer>().flipY == false)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(kunaiSpeed, 0);
        }
        else if(this.GetComponent<SpriteRenderer>().flipY == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-kunaiSpeed, 0);
        }
         
    }

    //function when kunai hits with something
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if it hits with the player
        if (collision.CompareTag("Enemy") && (this.GetComponent<SpriteRenderer>().enabled == true))
        {
            //reduce enemy health and play the kunai hitting sound and then after playing the sound destroy this gameobject
            collision.GetComponent<EnemyController>().enemyCurrentHealth -= kunaiDamage;
            weaponHitSound.Play();
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject,1f);
            
        }
        //else if it hits an obstacle on its path
        else if (collision.CompareTag("Obstacle"))
        {
            //just destroy the kunai
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
