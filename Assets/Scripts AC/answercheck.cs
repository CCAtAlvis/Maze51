using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answercheck : MonoBehaviour {

    public GameObject button;

    public static int direction;

    public static int flag=0;
    //public bool 
    // Update is called once per frame


    private void OnMouseDown()
    {
        if (flag == 0) { 
        direction = swaper.num;
        button.transform.localScale -= new Vector3(0, 0, 0.5f);
        float pos = button.transform.position.x;
            //Debug.Log(button.transform.position.x);

            if (pos < 0 && direction == 0)
            {
                Debug.Log("Success");
                flag = 1;
            }
            else if (pos == 0 && direction == 1)
            {
                Debug.Log("Success");
                flag = 1;
            }
            else if (pos > 0 && direction == 2)
            {
                Debug.Log("Success");
                flag = 1;
            }
            else
            {
                Debug.Log("Failed");
                flag = 1;
            }
                
        }
    }
    
}
