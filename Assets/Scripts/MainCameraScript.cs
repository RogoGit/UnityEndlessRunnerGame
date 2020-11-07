using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{

    private Transform lookAt;
    private Vector3 camOffset;
    private Vector3 moveVector;

    private float animationDuration = 2.0f; // 2 seconds
    private Vector3 animCamOffset = new Vector3(0,5,5);
    private float transition = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // searching fpr player object by tag
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        camOffset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector =  lookAt.position + camOffset;

        // restrict camera - in runners we have to see the whole road
        // X axis
        moveVector.x = 0;
        // Y axis
        moveVector.y = Mathf.Clamp(moveVector.y,3,5); // restricting camera range

        if (transition > 1.0f)
        {
            // normal game mod
            transform.position = lookAt.position + camOffset;
        }
        else
        {
            // animation on game starting
            transform.position = Vector3.Lerp(moveVector + animCamOffset, moveVector, transition); //linear interpolation
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }
        
    }
}
