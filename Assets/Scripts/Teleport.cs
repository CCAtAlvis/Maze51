using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject trans;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("entered");
            other.gameObject.transform.position = trans.transform.position;
        }
    }

    // Update is called once per frame
    void Update () {
	}
}
