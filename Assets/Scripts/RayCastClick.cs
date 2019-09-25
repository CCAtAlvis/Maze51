using UnityEngine;

public class RayCastClick : MonoBehaviour
{
    public float viewDistance = 10.0f;
    public string RayInput()
    {
        RaycastHit hit;
        Ray frontRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * viewDistance);

        if (Physics.Raycast(frontRay, out hit, viewDistance))
        {
            if (hit.collider.tag == "ActionsMithil")
            {
                return hit.transform.name;
            }
        }
        return "Love";
    }
    public GameObject RayReference()
    {
        RaycastHit hit;
        Ray frontRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * viewDistance);

        if (Physics.Raycast(frontRay, out hit, viewDistance))
        {
            if (hit.collider.tag == "ActionsMithil")
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }
}
