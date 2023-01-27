using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerControllerScript; //to access this script in other scripts 

    public float moveSpeed = 10f; //movement speed handler of the player
    public float jumpSpeed = 10f; //jump scale handler of the player
    public float moveSpeedAxis; //to be referenced for the horizontal input axis of the input manager
    public float jumpSpeedAxis; //to be referenced for the vertical input axis of the input manager
    public bool attack = false; //to be referenced for the fire animation caller

    private Rigidbody2D thisChar; //Rigidbody component of the player sprite to add velocities for movement of the object

    public Transform groundCheckObject; //the transforms for checking ground
    public LayerMask whatIsGround; //layers which are marks as ground
    public float groundRadius = 0.2f; //radius for the physics ground checking circle collider

    private Animator playerAnimator; //variable to reference the animator component in the player gameobject
    private SpriteRenderer playerSpriteRenderer; //variable to reference the sprite renderer component in the player gameobject


    // Start is called before the first frame update
    void Start()
    {
        thisChar = this.GetComponent<Rigidbody2D>(); //assigning the rigid body component of the gameobject to the script to be called later
        playerAnimator = this.GetComponent<Animator>(); //assigning the player animator 
        playerSpriteRenderer = this.GetComponent<SpriteRenderer>(); //assigning the player sprite renderer
        
        //assigning the player controller script to be referenced in other scripts if its not assigned earlier
        if (playerControllerScript == null)
        {
            playerControllerScript = this;
        }
    }

    private void FixedUpdate()
    {
        //assigning input values taken from Input Manager
        moveSpeedAxis = Input.GetAxis("Horizontal"); 
        jumpSpeedAxis = Input.GetAxis("Jump");

        //make the player able to move only if PlayerAttack animation is not playing
        if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("PlayerAttack"))
        {
            //adding velocity to the rigidbody component based on the horizontal move axis inputs
            thisChar.velocity = new Vector2(moveSpeedAxis * moveSpeed, thisChar.velocity.y);
        }

        

        //if the transform position at player's foot collides with a ground object and Jump axis input is greater than 0
        if (Physics2D.OverlapCircle(groundCheckObject.position, groundRadius, whatIsGround) && jumpSpeedAxis > 0)
        {
            //make the player rigidbody have a upward velocity;
            thisChar.AddForce(new Vector2(0, jumpSpeed));
        }

        //setting the float value of the Movement parameter in the animator to call the running animation
        playerAnimator.SetFloat("Movement", Mathf.Abs(moveSpeedAxis));
        //setting the float value of the Jump parameter in the animator to call the Jumping animation
        playerAnimator.SetFloat("Jump", jumpSpeedAxis);
        //setting the boolean value of the Attack parameter in the animator to call the attacking animation
        playerAnimator.SetBool("Attack", attack);

        //if player hits the fire1 input button in the input manager
        if (Input.GetAxis("Fire1") > 0)
        {
            //set the value of the bool attack to true
            attack = true;
            //stopping the player from moving
            thisChar.velocity = Vector2.zero;
        }
        else
        {
            //else make it false
            attack = false;
        }

        //flipping the sprite renderer of the player correspending to the direction that the player is moving
        if (moveSpeedAxis < 0 && playerSpriteRenderer.flipX == false)
        {
            playerSpriteRenderer.flipX = true;
        }
        else if (moveSpeedAxis > 0 && playerSpriteRenderer.flipX == true)
        {
            playerSpriteRenderer.flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //player dying function
    public void PlayerDead()
    {
        if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("PlayerDying"))
        {
            //triggering player dying animation
            playerAnimator.SetTrigger("isDead");

            //Invoking the UI callers after playing the player dead animation
            Invoke("PlayerDeadUI", 2f);
        }       
    }

    //function for showing the UI screen after player dying
    private void PlayerDeadUI()
    {
        //pausing the time flow of the game
        Time.timeScale = 0;
    } 
}
