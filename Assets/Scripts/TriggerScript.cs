using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private PuzzleController PC;
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            Debug.Log("Entered");
            PC.cvObject.SetActive(true);
            player.transform.position = PC.puzzleSpawnTransform.transform.position;
            player.gameObject.GetComponent<CubeMovement>().enabled = false;
        }
    }

    void Start()
    {
        PC = GetComponent<PuzzleController>();
    }

    void Update()
    {

    }
}
