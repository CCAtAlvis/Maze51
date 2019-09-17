using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastClick : MonoBehaviour
{
    RaycastHit hit;
    
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
                
        if (Physics.Raycast(transform.position, fwd, 10))
        {
            if (Input.GetButtonUp("Fire1"))
            {
                
            }
        }
    }
}
