using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public GameObject Player;

    public Transform failureTransform;
    public Transform successTransform;
    public Transform puzzleSpawnTransform;

    public GameObject puzzleTrigger;

    public GameObject cvObject;

    public bool doesRequireCanvas;

    public void PuzzleSolved()
    {
        puzzleTrigger.GetComponent<Renderer>().material.color = Color.green;
        Player.transform.position = successTransform.transform.position;

        if (doesRequireCanvas)
            cvObject.SetActive(false);

        Player.GetComponent<CubeMovement>().enabled = true;
    }

    public void PuzzleFailed()
    {
        Player.transform.position = failureTransform.transform.position;

        if (doesRequireCanvas)
            cvObject.SetActive(false);

        Player.GetComponent<CubeMovement>().enabled = true;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
