using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public Transform cameraTransform; // Drag & drop here the transform of the camera rotated by the VR plugin

    public float toggleAngle = 30.0f;

    public float speed = 3.0f;

    public bool moveforward;

    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        
    }

    void Update()
    {

        if (moveforward)
        {
            Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);

            cc.SimpleMove(forward * speed);
        }
            

    }
}
