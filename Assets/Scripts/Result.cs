using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour {


    public static void Success()
    {
        Debug.Log("Success");
        //GameObject.Find("Canvas").GetComponent<ButtonManipulatorScript>().number.text = "SUCCESS";
    }

    public static void Fail()
    {
        Debug.Log("Fail");
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
