using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerToMidScene : MonoBehaviour
{
    public static int maze;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "camObj")
        {
            maze = Random.Range(0, 2);
            SceneManager.LoadScene("MidScene");
        }
    }
}
