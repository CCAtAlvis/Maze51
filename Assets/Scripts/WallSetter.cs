using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallSetter : MonoBehaviour
{
    public GameObject leftTop, leftBottom, rightTop, rightBottom;
    private GameObject[] holeFiller = new GameObject[4];
    public List<GameObject> bricksList = new List<GameObject>();
    private List<int> done = new List<int>();
    int index = 0, j = 0;
    private List<int> soln = new List<int>() { 1, 3, 6, 0 };
    // Use this for initialization
    void Start()
    {
        for (int i = 1; i < 9; ++i)
            bricksList[i].GetComponent<cakeslice.Outline>().enabled = false;
    }

    void checkSolution()
    {
        if (done.SequenceEqual(soln))
            Collapse();
        else
            Debug.Log("Fail");
    }

    void Collapse()
    {
        Debug.Log("BOOM!");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            holeFiller[j] = bricksList[index];
            done.Add(index);
            if (j == 0)
            {
                holeFiller[0].transform.position = leftTop.transform.position;
            }
            else if (j == 1)
            {
                holeFiller[1].transform.position = rightTop.transform.position;
            }
            else if (j == 2)
            {
                holeFiller[2].transform.position = leftBottom.transform.position;
            }
            else if (j == 3)
            {
                holeFiller[3].transform.position = rightBottom.transform.position;
                checkSolution();
            }
            ++j;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            bricksList[index].GetComponent<cakeslice.Outline>().enabled = false;
            index = ++index % (bricksList.Count);
            if (done != null && done.Contains(index))
                index = ++index % (bricksList.Count);
            if (done != null && done.Contains(index))
                index = ++index % (bricksList.Count);
            if (done != null && done.Contains(index))
                index = ++index % (bricksList.Count);
            if (done != null && done.Contains(index))
                index = ++index % (bricksList.Count);
            bricksList[index].GetComponent<cakeslice.Outline>().enabled = true;
        }
    }
}
