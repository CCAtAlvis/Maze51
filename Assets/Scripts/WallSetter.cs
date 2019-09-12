using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WallSetter : MonoBehaviour
{
    public GameObject trig;
    public GameObject[] MiddleHoleOrientation = new GameObject[4];    // LeftTop, RigthTop, LeftBottom, RightBottom
    private GameObject[] holeFiller = new GameObject[4]; // The 
    public List<GameObject> BricksList = new List<GameObject>(); // The list of bricks to the right
    private List<int> YourSolutionList = new List<int>();
    int index = 0, j = 0;
    private readonly List<int> ActualSolutionList = new List<int>() { 1, 3, 6, 0 };

    public void init()
    {
        for (int i = 1; i < 9; ++i)
            BricksList[i].GetComponent<cakeslice.Outline>().enabled = false;
        YourSolutionList.Clear();
        index = 0; j = 0;
    }

    void Start()
    {
        // The bricks are all outlined at the beginning.
        // We disable the outline from 1 to 8
        init();
    }

    void CheckSolution()
    {
        if (YourSolutionList.SequenceEqual(ActualSolutionList))
            trig.GetComponent<PuzzleController>().PuzzleSolved(4);
        else
            trig.GetComponent<PuzzleController>().PuzzleFailed(4);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            holeFiller[j] = BricksList[index];
            YourSolutionList.Add(index);

            holeFiller[j].transform.position = MiddleHoleOrientation[j].transform.position;

            if (j == 3)
            {
                CheckSolution();
            }
            ++j;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            BricksList[index].GetComponent<cakeslice.Outline>().enabled = false;
            index = ++index % (BricksList.Count);
            if (YourSolutionList != null && YourSolutionList.Contains(index))
                index = ++index % (BricksList.Count);
            if (YourSolutionList != null && YourSolutionList.Contains(index))
                index = ++index % (BricksList.Count);
            if (YourSolutionList != null && YourSolutionList.Contains(index))
                index = ++index % (BricksList.Count);
            if (YourSolutionList != null && YourSolutionList.Contains(index))
                index = ++index % (BricksList.Count);
            BricksList[index].GetComponent<cakeslice.Outline>().enabled = true;
        }
    }
}
