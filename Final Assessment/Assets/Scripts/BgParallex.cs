using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgParallex : MonoBehaviour
{
    private float length, startPos; //to use as holders for the length of the sprite and the start position of the sprite.
    public GameObject cam; //to make reference to the camera in the scene
    public float parallexEffect; //to set up reletive movement speed 

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x; //start x position of the background image component
        length = GetComponent<SpriteRenderer>().bounds.size.x; //length of the image
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallexEffect)); //calculating the distance that the image component has moved with the parellex effect when the cam is moved
        float dist = (cam.transform.position.x * parallexEffect); //setting up the positions for individual components that the script is attached to reletive to the camera object's position

        //moving the image elements that this script has attached to new position reletive to the camera position adding a parallex moving effect to the entire background image
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        //if the image component has moved beyond its bounds then updating the initial starting position of the image element correspondingly reducing or increasing by the length of the component so that it can be repeated infinitly 
        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;
    }
}
