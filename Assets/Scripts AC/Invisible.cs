using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour {

    public GameObject text1;

    public static string s1,s2;

    static int temp;

    void Start()
    {
        //temp = Random.Range(0, 4);
        temp = 0;

        switch (temp)
        {
            case 0:
                s1=text1.GetComponent<TextMesh>().text = "When I grow up, I want to be a ranger.";
                s2 = "When I grow up, I want to           anger.";
                break;
            case 1:
                s1=text1.GetComponent<TextMesh>().text = "I agree not to eat all the food.";
                s2 = "I a           ot to eat all the food.";
                break;
            case 2:
                s1=text1.GetComponent<TextMesh>().text = "Bob decided to jump in, knowing that this is his only choice.";
                s2 = "Bob decided to jum          nowing that this is his only choice.";
                break;
            case 3:
                s1=text1.GetComponent<TextMesh>().text = "The sunset makes Cairo seem magnificent.";
                s2 = "The sunset makes Cai         em magnificent.";
                break;

            default:
                Debug.Log("failed randomizing");
                break;

        }


    }

     void OnMouseOver()
    {
        text1.GetComponent<TextMesh>().text=s2;
    }

     void OnMouseExit()
    {
        text1.GetComponent<TextMesh>().text = s1;
    }
}
