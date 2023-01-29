using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public int amountOfDamage = 10;
    public int trapSpeed = 1;
    public bool moveDown = true;
    private float startYPos;
    public float hideYPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the game object that collide with the trap game object has the tag of "player", reduce the player health by an amount by calling the dealDamage function which was created on Game Manager script
        if (collision.CompareTag("Player"))
        {
            GameManagerScript.thisGameManagerScript.currentHealth -= amountOfDamage;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Moving the trap up and down with a linear rythm 
        if (moveDown == true)
        {
            transform.Translate(Vector2.down * trapSpeed * Time.deltaTime);

            if (transform.position.y <= hideYPos)
            {
                moveDown = false;
            }
        }
        if (moveDown == false)
        {
            transform.Translate(Vector2.up * trapSpeed * Time.deltaTime);

            if (transform.position.y >= startYPos)
            {
                moveDown = true;
            }
        }

    }
}
