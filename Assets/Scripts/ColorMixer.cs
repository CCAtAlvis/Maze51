using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorMixer : MonoBehaviour
{
    public GameObject trig;

    public PuzzleContro2 Player;
    public RayCastClick rayer;

    Dictionary<string, Color> quotes =
    new Dictionary<string, Color>();

    public GameObject[] coloredSpheres;
    int currSphere = 0;
    Color resultColor;
    Color tempColor;
    Color yellow = new Color(1, 1, 0, 1);

    string str;
    string[] quoteStrings = new string[12];

    public Text textui;
    public void Init()
    {
        coloredSpheres[0].GetComponent<Renderer>().material.color = yellow;
        coloredSpheres[1].GetComponent<Renderer>().material.color = Color.red;
        coloredSpheres[2].GetComponent<Renderer>().material.color = Color.blue;

        quoteStrings[0] = "Yellow";
        quoteStrings[1] = "Yellow2";
        quoteStrings[2] = "Red";
        quoteStrings[3] = "Red2";
        quoteStrings[4] = "Blue";
        quoteStrings[5] = "Blue2";
        quoteStrings[6] = "Orange";
        quoteStrings[7] = "Orange2";
        quoteStrings[8] = "Purple";
        quoteStrings[9] = "Purple2";
        quoteStrings[10] = "Gray";
        quoteStrings[11] = "Gray2";

        quotes.Add(quoteStrings[0], yellow);
        quotes.Add(quoteStrings[1], yellow);
        quotes.Add(quoteStrings[2], Color.red);
        quotes.Add(quoteStrings[3], Color.red);
        quotes.Add(quoteStrings[4], Color.blue);
        quotes.Add(quoteStrings[5], Color.blue);
        quotes.Add(quoteStrings[6], Color.Lerp(yellow, Color.red, 0.5f));
        quotes.Add(quoteStrings[7], Color.Lerp(yellow, Color.red, 0.5f));
        quotes.Add(quoteStrings[8], Color.Lerp(Color.blue, Color.red, 0.5f));
        quotes.Add(quoteStrings[9], Color.Lerp(Color.blue, Color.red, 0.5f));
        quotes.Add(quoteStrings[10], Color.Lerp(Color.blue, yellow, 0.5f));
        quotes.Add(quoteStrings[11], Color.Lerp(Color.blue, yellow, 0.5f));

        str = quoteStrings[Random.Range(0, quoteStrings.Length)];

        textui.text = str;
    }
    void Start()
    {
        Init();
    }

    Color AddColor()
    {
        Color temp = gameObject.GetComponent<Renderer>().material.color;
        Color col = Color.Lerp(tempColor, temp, 0.5f);
        return col;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // To select the color of current sphere
            tempColor = coloredSpheres[currSphere].GetComponent<Renderer>().material.color;
            if (gameObject.GetComponent<Renderer>().material.color == Color.white)
                gameObject.GetComponent<Renderer>().material.color = tempColor;
            else
                gameObject.GetComponent<Renderer>().material.color = AddColor();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            // Cycle spheres
            currSphere = ++currSphere % 3;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (quotes[str] == gameObject.GetComponent<Renderer>().material.color)
                trig.GetComponent<PuzzleController>().PuzzleSolved(3);
            else
            {
                trig.GetComponent<PuzzleController>().PuzzleFailed(3);
            }
        }
    }
}
