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
    public WallSetter P4ScriptObject;

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
        if (x == 2)
        {
            P3ScriptObject.enabled = true;
        }
        if (x == 3)
        {
            P4ScriptObject.enabled = true;
        }
        if (x == 4)
        {

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
        }
        if (x == 4)
        {
            P4ScriptObject.init();
        }
        Player.GetComponent<CubeMovement>().enabled = true;
    }
}
