using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilepress : MonoBehaviour {

    public GameObject tile;

    public int temp;

    private void OnMouseDown()
    {
       
        if (pathfollow.answerkey[pathfollow.index] == temp)
            pathfollow.index += 1;
        else
            Debug.Log("failed");
        if (pathfollow.index > 3)
            Debug.Log("success");
    }
}
