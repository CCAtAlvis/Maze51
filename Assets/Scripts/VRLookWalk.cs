using UnityEngine;

public class VRLookWalk : MonoBehaviour
{
    public Transform cameraTransform;
    public float toggleAngle = 10.0F;
    public float speed = 3.0F;
    public bool moveForward;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponentInParent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        //if (cameraTransform.eulerAngles.x >= toggleAngle
        //  && cameraTransform.eulerAngles.x <= 90.0f)
        if (Input.GetButton("Fire1"))
        {
            moveForward = true;
        }
        else
            moveForward = false;

        if (moveForward)
        {
            Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
            characterController.SimpleMove(forward * speed * toggleAngle / 5);
        }
    }
}
