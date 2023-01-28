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
    private Animator enemyAniController; //animation controller component of the enemy

    public float enemyMaxHealth = 100f; //enemy max health value
    public float enemyCurrentHealth; //enemy current health value

    public float enemyDamage = 20f; //enemy damage value
    private bool isAttack = false; //boolian to check the attacking state of the enemy

    private float attackReset = 0.7f; //attack countdown timer reset value
    private float enemyAttackCD; //attack countdown timer
    private bool directionChanged = false; //boolian to check whether the sprite direction has changed while triggering the attack animation


    // Start is called before the first frame update
    void Start()
    {
        enemyAniController = this.GetComponent<Animator>(); //assigning the animator component

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
    void FixedUpdate()
    {
        //if the idle walking animation is playing
        if (enemyAniController.GetCurrentAnimatorStateInfo(0).IsTag("idle"))
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

            //if enemy health is less than or equals to 0
            if (enemyCurrentHealth <= 0)
            {
                //playing the enemy dying animation
                enemyAniController.SetTrigger("EnemyDie");
                //destroy this game object after 1s
                Destroy(this.gameObject, 1f);
            }  
        }

        //if enemy is attacking
        if (isAttack)
        {
            //run the attack countdown timer 
            if (enemyAttackCD > 0)
            {
                enemyAttackCD -= 1 * Time.deltaTime;
            }
            else
            {
                enemyAttackCD = 0;
            }

            //if the countdown timer ran out make the enemy deal damage to the player and reset the timer
            if (enemyAttackCD == 0)
            {
                GameManagerScript.thisGameManagerScript.currentHealth -= enemyDamage;
                enemyAttackCD = attackReset;
            }
        }
    }

    //function that triggers when something enters inside the collider trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the object enters the collider is the player
        if (collision.CompareTag("Player"))
        {
            //loop enemy attack animation
            enemyAniController.SetBool("EnemyAttack", true);
            //reset the enemy attack countdown
            enemyAttackCD = attackReset;
            //set enemy as attacking to be referenced easily
            isAttack = true;

            //flipping the enemy sprite to face in the direction of the player position
            if ((collision.transform.position.x > this.transform.position.x) && (enemySprite.flipX == true))
            {
                enemySprite.flipX = false;
                directionChanged = true;
            }
            else if ((collision.transform.position.x < this.transform.position.x) && (enemySprite.flipX == false))
            {
                enemySprite.flipX = true;
                directionChanged = true;
            }
        }
    }



    //function that triggers when something exit out of the collider trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //stopping the enemy attack animation
            enemyAniController.SetBool("EnemyAttack", false);
            //set enemy as not attacking to be referenced easily
            isAttack = false;

            //if the enemy sprite direction was altered before make if back to how it was before
            if (directionChanged)
            {
                directionChanged = false;

                if (enemySprite.flipX)
                {
                    enemySprite.flipX = false;
                }
                else
                {
                    enemySprite.flipX = true;
                }
            }
        }
    }
}
