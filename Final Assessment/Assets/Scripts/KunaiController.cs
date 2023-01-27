using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public float kunaiSpeed; //speed in which kunai will be moving 

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
