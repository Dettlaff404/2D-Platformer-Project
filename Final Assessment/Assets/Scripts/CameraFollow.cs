using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;

    private Vector3 velocity = Vector3.zero;
    private Vector3 movePosition;


    private void Start()
    {
        movePosition = new Vector3(target.position.x, transform.position.y, transform.position.z) + offset;
    }

    private void FixedUpdate()
    {
        //follow the position of the player if it exist in the level with a smooth damping effect
        if (GameObject.Find("Player") != null)
        {
            movePosition.x = target.position.x + offset.x;
            transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
        }

    }
}
