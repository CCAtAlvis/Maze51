using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreaker : MonoBehaviour {
    //1 se right, 0.5 se upar
    public GameObject[] arr = new GameObject[10];
    public GameObject rot;
    int[,] wall = new int[,] {
    { 0, 0, 0, 0, 9 },
    { 0, 1, 0, 5, 0 },
    { 7, 0, 2, 0, 0 },
    { 0, 3, 0, 0, 8 },
    { 0, 0, 0, 4, 0 },
    { 6, 0, 0, 0, 0 }
    };
	// Use this for initialization
	void Start () {
		for(int i=0;i<5;++i)
        {
            for(int j=0;j<5;++j)
            {
                if (wall[i, j] != 0)
                {
                    Instantiate(arr[wall[i, j]], new Vector3(j * 1.0F, i * 0.5f, 0), rot.transform.rotation);
                    arr[wall[i, j]].transform.localScale = new Vector3(25, 50, 20);
                }
                else
                    Instantiate(arr[0], new Vector3(j * 1.0F, i * 0.5f, 0), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
