using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilepress : MonoBehaviour
{

    public GameObject tile;
    public int number, f = 0;

    public PuzzleContro2 Player;

    //void OnCollisionEnter(Collision collision)
    //{
    //    Collider collider = collision.collider;
    //    Debug.Log(collider.gameObject.name);

    //    if (pathfollow.answerkey[pathfollow.temp] == number && collider.gameObject.name != "TP" && f == 0)
    //    {
    //        pathfollow.temp++;
    //        f = 1;
    //        Debug.Log("yess" + number);
    //        tile.transform.localScale -= new Vector3(0, 0.1f, 0);
    //        if (pathfollow.temp >= 4)
    //            Player.PuzzleSolved(2);
    //    }
    //    //else if(collision.collider.gameObject.name==)
    //    else if ((number == 0 || number == 1 || number == 2 || number == 3) && collider.gameObject.name != "TP" && f == 0)
    //    {
    //        Debug.Log(pathfollow.answerkey[pathfollow.temp] + "" + number);
    //        Player.PuzzleFailed(2);
    //    }
    //}

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
        if (pathfollow.answerkey[pathfollow.temp] == number && collider.gameObject.name != "TP" && f == 0)
        {
            pathfollow.temp++;
            f = 1;
            Debug.Log("yess" + number);
            tile.transform.localScale -= new Vector3(0, 0.1f, 0);
            if (pathfollow.temp >= 4)
                Player.PuzzleSolved(2);
        }
        //else if(collision.collider.gameObject.name==)
        else if ((number == 0 || number == 1 || number == 2 || number == 3) && collider.gameObject.name != "TP" && f == 0)
        {
            //Debug.Log(pathfollow.answerkey[pathfollow.temp]+""+number);
            Player.PuzzleFailed(2);
        }

    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger")
        {
            GameObject enterTrig = other.gameObject;
            int ind = Array.IndexOf(triggers, enterTrig);
            transform.position = sceneSpawnPoints[ind].transform.position;
            transform.GetChild(0).GetComponent<VRLookWalk>().enabled = false;
            //scriptObjects[ind].SetActive(true);
        }
    }*/
}
