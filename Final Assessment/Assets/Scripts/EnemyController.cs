using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController enemyControllerScript; //to reference this script in other scripts

    public float enemyMoveSpeed = 1f; //movement spead of the enemy
    public float unitsToMove = 2f; //distance that the enemy will patrol to 
    private float startPos; //starting position of the enemy
    public bool moveRight = true; //boolian value to keep track of the direction that the enemy will be moving to

    public SpriteRenderer enemySprite; //sprite renderer component of the enemy

    public float enemyMaxHealth = 100f; //enemy max health value
    public float enemyCurrentHealth;


    // Start is called before the first frame update
    void Start()
    {
        //recording the starting position of the enemy for later conditions
        startPos = transform.position.x;

        //assigning this script to be referenced in other scripts
        if (enemyControllerScript == null)
        {
            enemyControllerScript = this;
        }

        enemyCurrentHealth = enemyMaxHealth; //setting enemy health

    }

    // Update is called once per frame
    void Update()
    {
        //move the enemy right if move right value is true
        if (moveRight == true)
        {
            transform.Translate(Vector2.right * Time.deltaTime * enemyMoveSpeed);

            //if the enemy pass a certain distance (distance value of starting position + units to move value) then make the enemy flip and turn the move right value to false
            if (transform.position.x >= (startPos + unitsToMove))
            {
                moveRight = false;
                enemySprite.flipX = true;
            }
        }
        //if the move right value is not true make the enemy move left
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * enemyMoveSpeed);

            //if the enemy pass the starting position, make him turn around and assign move right value to true
            if (transform.position.x <= startPos)
            {
                moveRight = true;
                enemySprite.flipX = false;
            }
        }

    }
}
