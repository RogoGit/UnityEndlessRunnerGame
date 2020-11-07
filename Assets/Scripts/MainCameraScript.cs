using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{

    private Transform lookAt;
    private Vector3 camOffset;

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
        transform.position = lookAt.position + camOffset;
    }
}
