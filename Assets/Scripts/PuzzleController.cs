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
    public GameObject cvObject;

    public bool doesRequireCanvas;

    public void PuzzleSolved()
    {
        puzzleTrigger.GetComponent<Renderer>().material.color = Color.green;
        puzzleTrigger.GetComponent<BoxCollider>().enabled = false;
        Player.transform.position = successTransform.transform.position;

        if (doesRequireCanvas)
            cvObject.SetActive(false);

        Player.GetComponent<CubeMovement>().enabled = true;
    }

    public void PuzzleFailed(int x)
    {
        Player.transform.position = failureTransform.transform.position;

        if (doesRequireCanvas)
            cvObject.SetActive(false);
        if(x==1)
        P1ScriptObject.init() ;
        if(x==2)
        P2ScriptObject.init();
        Player.GetComponent<CubeMovement>().enabled = true;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
