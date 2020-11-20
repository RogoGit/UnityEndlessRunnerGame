using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovings : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float defaultSpeed = 10.0f;
    private float characterSpeed;
    private float verticalSpeed = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 2.0f; // 2 seconds
    private bool isPlayerDead = false;
    private bool isPlayerOnWater = false;
    private float startTime;
    private float beforeWaterSpeed;
    private int beforeWaterGameSpeed;

    public Animator anim;

    public void setSpeed(int additionalSpeed)
    {
        characterSpeed = defaultSpeed + (additionalSpeed * 2);
        beforeWaterSpeed = characterSpeed;
    }

    public bool getIsOnWater() {
        return isPlayerOnWater;
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
        anim.SetBool("isPlayerDead", false);
        anim.SetBool("isPlayerOnWater", false);
        characterSpeed = defaultSpeed;
        beforeWaterSpeed = characterSpeed;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        // check if player died
        if (isPlayerDead)
            return;

        // game start animation
        if (Time.time - startTime < animationDuration) 
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
            if (verticalSpeed < -8.0f) DIE();
        }

        // Left-right (x axis)
        moveVector.x = Input.GetAxisRaw("Horizontal") * characterSpeed;

        // Up-down (y axis)
        moveVector.y = verticalSpeed;

        // Forward-backward (z axis)
        moveVector.z = characterSpeed;

        controller.Move(moveVector * Time.deltaTime);
    }

    // player death
    private void DIE()
    {
        //Debug.Log("DEAD");
        isPlayerDead = true;
        anim.SetBool("isPlayerDead", true);
        GetComponent<ScoreHandler>().onDeath();
    }

    // called every time player hits
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // game must be over only if it is front hit
        if ((hit.point.z > transform.position.z + controller.radius) && (hit.gameObject.tag == "Obstacle"))
        {
            DIE();
        }
    }

    void OnTriggerEnter(Collider coll) {
        
        if (coll.tag == "Water") {
            isPlayerOnWater = true;
            anim.SetBool("isPlayerOnWater", true);
            characterSpeed = 3.0f;
            beforeWaterGameSpeed = GetComponent<ScoreHandler>().getGameSpeedLevel();
            GetComponent<ScoreHandler>().setGameSpeedLevel(1);
        }

    }

    void OnTriggerExit(Collider coll) {
        
        if (coll.tag == "Water") {
            isPlayerOnWater = false;
            anim.SetBool("isPlayerOnWater", false);
            characterSpeed = beforeWaterSpeed;
            GetComponent<ScoreHandler>().setGameSpeedLevel(beforeWaterGameSpeed);
        }

    }

}
