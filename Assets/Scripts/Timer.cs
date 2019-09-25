using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    static public float timer;
    static public Text TimeDisplayText;

	void Update () {
        timer += Time.deltaTime;
        if(timer >= 8*60)
        {
            TimeDisplayText.text = "8:00";
        }
	}
}
