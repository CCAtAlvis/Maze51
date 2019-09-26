using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swaper : MonoBehaviour {

    public Material left,middle,right;
    public RayCastClick rayer;
    public PuzzleContro2 Player;
    //in the editor this is what you would set as the object you wan't to change
    public GameObject Object;

    public static int num; 

    void Start()
    {
        //num = Random.Range(0,3);
        num = Random.Range(0, 3);
        switch(num)
        {
            case 0:
                Object.GetComponent<MeshRenderer>().material = left;
                break;
            case 1:
                Object.GetComponent<MeshRenderer>().material = middle;
                break;
            case 2:
                Object.GetComponent<MeshRenderer>().material = right;
                break;
            default:
                Debug.Log("sorry");
                break;
        }
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (rayer.RayInput() == "RButton" && num == 0)
            {
                Debug.Log("Success");
                Player.PuzzleSolved(0);
            }
            else if (rayer.RayInput() == "GButton" && num == 1)
            {
                Debug.Log("Success");
                Player.PuzzleSolved(0);
            }
            else if (rayer.RayInput() == "YButton" && num == 2)
            {
                Debug.Log("Success");
                Player.PuzzleSolved(0);
            }
            else if (rayer.RayInput() == "YButton" || rayer.RayInput() == "RButton" || rayer.RayInput() == "GButton" )
                Player.PuzzleFailed(0);
            }
    }

}
