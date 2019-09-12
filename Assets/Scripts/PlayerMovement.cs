using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public Text tx;
    string str = "Start";
    // Use this for initialization

    //void OnGUI()
    //{
    //    Event e = Event.current;
    //    if (e.isKey)
    //        str += "\nCode : "+ e.keyCode;
    //}

    void Start () {
        tx.text = str;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            str += "\nDown 0";
        if (Input.GetMouseButtonUp(0))
            str += "\nUp 0";
        if (Input.GetMouseButtonDown(1))
            str += "\nDown 1";
        if (Input.GetMouseButtonUp(1))
            str += "\nUp 1";

        tx.text = str;
	}
}
