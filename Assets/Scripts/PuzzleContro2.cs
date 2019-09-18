using System;
using UnityEngine;

public class PuzzleContro2 : MonoBehaviour
{
    public GameObject[] triggers;
    public GameObject[] failurePoints;
    public GameObject[] sceneSpawnPoints;
    public GameObject[] scriptObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger")
        {
            GameObject enterTrig = other.gameObject;
            int ind = Array.IndexOf(triggers, enterTrig);
            transform.position = sceneSpawnPoints[ind].transform.position;
            transform.GetChild(0).GetComponent<VRLookWalk>().enabled = false;
            scriptObjects[ind].SetActive(true);
        }
    }

    public void PuzzleSolved(int x)
    {
        triggers[x].GetComponent<Renderer>().material.color = Color.green;
        triggers[x].GetComponent<BoxCollider>().enabled = false;
        transform.position = triggers[x].transform.position;

        transform.GetChild(0).GetComponent<VRLookWalk>().enabled = true;
    }

    public void PuzzleFailed(int x)
    {
        transform.position = failurePoints[x].transform.position;

        transform.GetChild(0).GetComponent<VRLookWalk>().enabled = true;
    }
}
