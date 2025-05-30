﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Trickop : MonoBehaviour
{

    public GameObject num1, num2, operationobj, ans1, ans2;
    public PuzzleContro2 Player;
    public RayCastClick rayer;
    

    public static int a, b, co, ans,randomcolor,a1=0,a2=0;

    public static string[] op;

    public static int ac, bc;
    public Color[] objc;
    public Color[,] ansc;

    // Use this for initialization
    void Start()
    {

        a = Random.Range(1, 10);
        b = Random.Range(1, 10);
        co = Random.Range(0, 4);
        ac = Random.Range(0, 8);
        bc = Random.Range(0, 8);

        objc = new Color[8];

        objc[0] = new Color32(0, 0, 0, 255);            //black
        objc[1] = new Color32(255, 0, 0, 255);          //red
        objc[2] = new Color32(0, 255, 0, 255);          //green
        objc[3] = new Color32(255, 255, 0, 255);         //yellow
        objc[4] = new Color32(0, 0, 255, 255);          //blue
        objc[5] = new Color32(255, 0, 255, 255);        //magenta
        objc[6] = new Color32(0, 255, 255, 255);        //cyan
        objc[7] = new Color32(255, 255, 255, 255);      //white

        num1.GetComponent<TextMesh>().text = a.ToString();
        num2.GetComponent<TextMesh>().text = b.ToString();
        
        num1.GetComponent<TextMesh>().color = objc[ac];
        num2.GetComponent<TextMesh>().color = objc[bc];


        switch (co)
        {
            case 0:
                operationobj.GetComponent<TextMesh>().text = "#";
                break;
            case 1:
                operationobj.GetComponent<TextMesh>().text = "&";
                break;
            case 2:
                operationobj.GetComponent<TextMesh>().text = "$";
                break;
            case 3:
                operationobj.GetComponent<TextMesh>().text = "@";
                break;
            default:
                Debug.Log("operation selection failed");
                break;
        }




        ansc = new Color[8, 8];

        for (int i = 0; i < 8; i++)
            ansc[i, i] = objc[0];
        ansc[0, 1] = ansc[1, 0] = objc[0];
        ansc[0, 2] = ansc[2, 0] = objc[1];
        ansc[0, 3] = ansc[3, 0] = objc[2];
        ansc[0, 4] = ansc[4, 0] = objc[3];
        ansc[0, 5] = ansc[5, 0] = objc[4];
        ansc[0, 6] = ansc[6, 0] = objc[5];
        ansc[0, 7] = ansc[7, 0] = objc[6];

        ansc[1, 2] = ansc[2, 1] = objc[3];
        ansc[1, 3] = ansc[3, 1] = objc[2];
        ansc[1, 4] = ansc[4, 1] = objc[5];
        ansc[1, 5] = ansc[5, 1] = objc[4];
        ansc[1, 6] = ansc[6, 1] = objc[7];
        ansc[1, 7] = ansc[7, 1] = objc[6];

        ansc[2, 3] = ansc[3, 2] = objc[1];
        ansc[2, 4] = ansc[4, 2] = objc[6];
        ansc[2, 5] = ansc[5, 2] = objc[7];
        ansc[2, 6] = ansc[6, 2] = objc[4];
        ansc[2, 7] = ansc[7, 2] = objc[5];

        ansc[3, 4] = ansc[4, 3] = objc[7];
        ansc[3, 5] = ansc[5, 3] = objc[6];
        ansc[3, 6] = ansc[6, 3] = objc[5];
        ansc[3, 7] = ansc[7, 3] = objc[4];

        ansc[4, 5] = ansc[5, 4] = objc[1];
        ansc[4, 6] = ansc[6, 4] = objc[2];
        ansc[4, 7] = ansc[7, 4] = objc[3];

        ansc[5, 6] = ansc[6, 5] = objc[3];
        ansc[5, 7] = ansc[7, 5] = objc[2];

        ansc[6, 7] = ansc[7, 6] = objc[1];


        op = new string[4];

        op[0] = "#";   //greater number sqaure - other number
        op[1] = "&";    //output the same numbers as above
        op[2] = "$";    //combine numbers and reverse
        op[3] = "@";    //(hcf)^2

        switch (co)
        {
            case 0:
                if (a > b)
                    ans = a * a - b;
                else
                    ans = b * b - a;
                break;
            case 1:
                ans = a*10+b;
                ans *= ans;
                break;
            case 2:
                ans = b * 10 + a;
                break;
            case 3:
                for (int i = 1; i < (a > b ? a : b); i++)
                {
                    if (a % i == 0 && b % i == 0)
                        ans = i;
                }
                break;
            default:
                Debug.Log("failed to calculate answer");
                break;
        }


        //ansobj.GetComponent<TextMesh>().color = ansc[ac, bc];
        //ansobj.GetComponent<TextMesh>().text = ans.ToString();
        

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("button");
            string s = rayer.RayInput();
            //Debug.Log(s);
            if (s == "Colorchange")
            {
                
                Debug.Log("cc");
                randomcolor = Random.Range(0, 8);
                ans1.GetComponent<TextMesh>().color = objc[randomcolor];
                ans2.GetComponent<TextMesh>().color = objc[randomcolor];
            }
            else if (rayer.RayInput() == "IncA1")
            {
                a1++;
                if (a1 > 9)
                    a1 = 0;
                ans1.GetComponent<TextMesh>().text = a1.ToString();

            }
            else if (rayer.RayInput() == "IncA2")
            {
                a2++;
                if (a2 > 9)
                    a2 = 0;
                ans2.GetComponent<TextMesh>().text = a2.ToString();

            }
            else if (rayer.RayInput() == "Submit")
            {
                if (ans1.GetComponent<TextMesh>().color == ansc[ac, bc] && (a1 * 10 + a2) == ans)
                {
                    Debug.Log("Success");
                    Player.PuzzleSolved(1);
                }
                else
                {
                    Debug.Log("Failure");
                    Player.PuzzleFailed(1);
                }
            }
        }
    }

}
	

