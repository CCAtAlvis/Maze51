using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallSetter : MonoBehaviour
{
    //public GameObject FailureTransformObject;
    //public GameObject SuccessTransformObject;
    //public GameObject[] MiddleHoleOrientation = new GameObject[4];    // LeftTop, RigthTop, LeftBottom, RightBottom
    //private GameObject[] holeFiller = new GameObject[4]; // The 
    //public List<GameObject> BricksList = new List<GameObject>(); // The list of bricks to the right
    //private List<int> YourSolutionList = new List<int>();
    //int index = 0, j = 0;
    //private List<int> ActualSolutionList = new List<int>() { 1, 3, 6, 0 };

    //void Start()
    //{
    //    // The bricks are all outlined at the beginning.
    //    // We disable the outline from 1 to 8
    //    for (int i = 1; i < 9; ++i)
    //        BricksList[i].GetComponent<cakeslice.Outline>().enabled = false;
    //}

    //void CheckSolution()
    //{
    //    if (YourSolutionList.SequenceEqual(ActualSolutionList))
    //        Collapse();
    //    else
    //    {
    //        GameObject.FindWithTag("Player").transform.position = og.transform.position;
    //    }

    //}

    //void Collapse()
    //{
    //    trig.GetComponent<Renderer>().material.color = Color.green;
    //    trig.GetComponent<Teleport>().enabled = false;
    //    GameObject.FindWithTag("Player").transform.position = og.transform.position;
    //}

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        holeFiller[j] = BricksList[index];
    //        YourSolutionList.Add(index);
    //        if (j == 0)
    //        {
    //            holeFiller[0].transform.position = leftTop.transform.position;
    //        }
    //        else if (j == 1)
    //        {
    //            holeFiller[1].transform.position = rightTop.transform.position;
    //        }
    //        else if (j == 2)
    //        {
    //            holeFiller[2].transform.position = leftBottom.transform.position;
    //        }
    //        else if (j == 3)
    //        {
    //            holeFiller[3].transform.position = rightBottom.transform.position;
    //            CheckSolution();
    //        }
    //        ++j;
    //    }
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        BricksList[index].GetComponent<cakeslice.Outline>().enabled = false;
    //        index = ++index % (BricksList.Count);
    //        if (YourSolutionList != null && YourSolutionList.Contains(index))
    //            index = ++index % (BricksList.Count);
    //        if (YourSolutionList != null && YourSolutionList.Contains(index))
    //            index = ++index % (BricksList.Count);
    //        if (YourSolutionList != null && YourSolutionList.Contains(index))
    //            index = ++index % (BricksList.Count);
    //        if (YourSolutionList != null && YourSolutionList.Contains(index))
    //            index = ++index % (BricksList.Count);
    //        BricksList[index].GetComponent<cakeslice.Outline>().enabled = true;
    //    }
    //}
}
