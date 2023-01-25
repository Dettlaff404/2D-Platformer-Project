using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; //movement speed handler of the player
    public float jumpSpeed = 10f; //jump scale handler of the player
    public float moveSpeedAxis; //to be referenced for the horizontal input axis of the engine 
    public float jumpSpeedAxis; //to be referenced for the vertical input axis of the engine 

    private Rigidbody2D thisChar; //Rigidbody component of the player sprite to add velocities for movement of the object

    public Transform groundCheckObject; //the transforms for checking ground
    public LayerMask whatIsGround; //layers which are marks as ground
    public float groundRadius = 0.2f; //radius for the physics ground checking circle collider

    // Start is called before the first frame update
    void Start()
    {
        thisChar = this.GetComponent<Rigidbody2D>(); //assigning the rigid body component of the gameobject to the script to be called later
        
    }

    private void FixedUpdate()
    {
        //assigning input values taken from Input Manager
        moveSpeedAxis = Input.GetAxis("Horizontal"); 
        jumpSpeedAxis = Input.GetAxis("Jump");

        //adding velocity to the rigidbody component based on the horizontal move axis inputs
        thisChar.velocity = new Vector2(moveSpeedAxis * moveSpeed, thisChar.velocity.y);

        //if the transform position at player's foot collides with a ground object and Jump axis input is greater than 0
        if (Physics2D.OverlapCircle(groundCheckObject.position, groundRadius, whatIsGround) && jumpSpeedAxis > 0)
        {
            //make the player rigidbody have a upward velocity;
            thisChar.AddForce(new Vector2(0, jumpSpeed));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
