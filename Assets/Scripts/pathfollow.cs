using System.Collections;
//using System;
using System.Collections.Generic;
using UnityEngine;

public class pathfollow : MonoBehaviour
{

    public GameObject[] block;

    public static int c = 0, ch, index = 0,temp;
    public RayCastClick rayer;
    public PuzzleContro2 Player;

    public static int[] xrand, zrand, answerkey;

    public int scale = 1, x, z;

    //block = new GameObject[4];
    // Use this for initialization
    void Start()
    {

        //block = new GameObject[4];
        xrand = new int[4];
        zrand = new int[4];

        
        for (int i = 0; i < 4; i++)
        {
            xrand[i] = Random.Range(x, x+2);
            zrand[i] = Random.Range(z, z+2);

            block[i].transform.position = new Vector3(xrand[i] * scale, 0.2f, zrand[i] * scale);

            switch (i)
            {
                case 0:
                    x = x + 2;
                    break;
                case 1:
                    x = x - 2;
                    z = z + 2;
                    break;
                case 2:
                    x = x + 2;
                    z = z + 2;
                    break;
                default:
                    break;
            }
        }

        //answerkey = new int[4];



        if (zrand[0] == zrand[1] && zrand[2] == zrand[3] && xrand[0] == xrand[2] && xrand[1] == xrand[3])
            ch = 0;     //square
        else if ((zrand[0] == zrand[1] && xrand[0] == xrand[2]) || (zrand[0] == zrand[1] && xrand[1] == xrand[3]) || (zrand[2] == zrand[3] && xrand[2] == xrand[0]) || (zrand[2] == zrand[3] && xrand[1] == xrand[3]))
            ch = 1;     //right angle triangle
        else if ((zrand[0] == zrand[1] && zrand[2] == zrand[3]) || (xrand[0] == xrand[2] && xrand[1] == xrand[3]))
            ch = 2;     //two parallel line
        else if (zrand[0] == zrand[1] || zrand[2] == zrand[3] || xrand[0] == xrand[2] || xrand[1] == xrand[3])
            ch = 3;     //line
        else
            ch = 4;     //nothing

        switch (ch)
        {
            case 0:
                answerkey = new int[] { 0, 1, 2, 3 };
                break;
            case 1:
                answerkey = new int[] { 1, 3, 2, 0 };
                break;
            case 2:
                answerkey = new int[] { 0, 2, 3, 1 };
                break;
            case 3:
                answerkey = new int[] { 0, 1, 3, 2 };
                break;
            default:
                answerkey = new int[] { 0, 3, 2, 1 };
                break;
        }
        Debug.Log(ch);
        temp = 0;
    }

    /*void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name );
        if (collision.gameObject == block[answerkey[temp]])
        {
            temp++;
            Debug.Log("yess");
            block[answerkey[temp]].transform.localScale -= new Vector3(0, 0.1f, 0);
            if (temp > 4)
                Player.PuzzleSolved(2);
        }
        //else if(collision.collider.gameObject.name==)
        else if (collision.gameObject == block[0] || collision.gameObject == block[1] || collision.gameObject == block[2] || collision.gameObject == block[3])
            Player.PuzzleFailed(2);

    }*/

    




}
