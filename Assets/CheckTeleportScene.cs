using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTeleportScene : MonoBehaviour
{
    public GameObject teleObj;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "camObj")
        {
            other.gameObject.transform.position = teleObj.transform.position;
        }
    }
}
