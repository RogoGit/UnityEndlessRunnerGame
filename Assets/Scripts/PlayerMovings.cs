using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovings : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float characterSpeed = 10.0f;
    private float verticalSpeed = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 2.0f; // 2 seconds

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {

        // game start animation
        if (Time.time < animationDuration) 
        {
            controller.Move(Vector3.forward * characterSpeed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero; // reseting direction every frame

        // check if player is on the floor
        if (controller.isGrounded) 
        {
            verticalSpeed = -0.5f;
        } 
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        // Left-right (x axis)
        moveVector.x = Input.GetAxisRaw("Horizontal") * characterSpeed;

        // Up-down (y axis)
        moveVector.y = verticalSpeed;

        // Forward-backward (z axis)
        moveVector.z = characterSpeed;

        controller.Move(moveVector * Time.deltaTime);
    }
}
