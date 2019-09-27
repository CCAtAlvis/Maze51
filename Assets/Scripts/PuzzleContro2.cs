using System;
using UnityEngine;

public class PuzzleContro2 : MonoBehaviour
{
    public GameObject[] triggers;
    public GameObject[] sceneSpawnPoints;
    private Transform temp;
    private GameObject enterTrig;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger")
        {
            enterTrig = other.gameObject;
            int ind = Array.IndexOf(triggers, enterTrig);
            transform.position = sceneSpawnPoints[ind].transform.position;
            if (ind != 2)
                transform.GetChild(0).GetComponent<VRLookWalk>().enabled = false;

            temp = enterTrig.transform;
        }
    }

    public void PuzzleSolved(int x)
    {
        enterTrig.GetComponent<Renderer>().material.color = Color.green;
        enterTrig.GetComponent<BoxCollider>().enabled = false;
        transform.position = temp.position;
        transform.rotation = temp.rotation;

        transform.GetChild(0).GetComponent<VRLookWalk>().enabled = true;
    }

    public void PuzzleFailed(int x)
    {
        transform.position = enterTrig.GetComponent<TriggerScript>().FPoint.transform.position;

        transform.GetChild(0).GetComponent<VRLookWalk>().enabled = true;
    }
}
