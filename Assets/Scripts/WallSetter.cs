using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WallSetter : MonoBehaviour
{
    readonly List<int> TrueSolution = new List<int>() { 1, 2, 3, 4 }; // Initialize solution list
    List<int> CurrentSolution = new List<int>();
    public GameObject[] Bricks;
    public GameObject[] Points;
    public PuzzleContro2 Player;
    public RayCastClick rayer;
    int x = 0;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (rayer.RayInput() == "psi")
            {
                CurrentSolution.Add(1);
                rayer.RayReference().transform.position = Points[x++].transform.position;
            }
            if (rayer.RayInput() == "tau")
            {
                CurrentSolution.Add(2);
                rayer.RayReference().transform.position = Points[x++].transform.position;
            }
            if (rayer.RayInput() == "pi")
            {
                CurrentSolution.Add(3);
                rayer.RayReference().transform.position = Points[x++].transform.position;
            }
            if (rayer.RayInput() == "nu")
            {
                CurrentSolution.Add(4);
                rayer.RayReference().transform.position = Points[x++].transform.position;
            }
            if (x == 4)
            {
                CheckSolution();
            }
        }
    }

    void CheckSolution()
    {
        if (TrueSolution.SequenceEqual(CurrentSolution))
        {
            Player.PuzzleSolved(3);
        }
        else
            Player.PuzzleFailed(3);
    }
}