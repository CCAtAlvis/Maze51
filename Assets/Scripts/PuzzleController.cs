using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public GameObject Player;

    public Transform failureTransform;
    public Transform successTransform;
    public Transform puzzleSpawnTransform;

    public GameObject puzzleTrigger;
    public ButtonManipulatorScript P1ScriptObject;
    public StringEncoder P2ScriptObject;
    public ColorMixer P3ScriptObject;

    public GameObject cvObject;

    public bool doesRequireCanvas;

    public void PuzzleSolved(int x)
    {
        puzzleTrigger.GetComponent<Renderer>().material.color = Color.green;
        puzzleTrigger.GetComponent<BoxCollider>().enabled = false;
        Player.transform.position = successTransform.transform.position;

        if (doesRequireCanvas)
            cvObject.SetActive(false);

        Player.GetComponent<CubeMovement>().enabled = true;
        if(x==2)
        {
            P3ScriptObject.enabled = true;
        }
    }

    public void PuzzleFailed(int x)
    {
        Player.transform.position = failureTransform.transform.position;

        if (doesRequireCanvas)
            cvObject.SetActive(false);
        if (x == 1)
        {
            P1ScriptObject.init();
        }
        if (x == 2)
        {
            P2ScriptObject.init();
        }
        if (x == 3)
        {
            P3ScriptObject.init();
            //P3ScriptObject.enabled = true;
        }
        Player.GetComponent<CubeMovement>().enabled = true;
    }
    void Start()
    {

    }
}
