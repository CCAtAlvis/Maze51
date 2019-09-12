using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManipulatorScript : MonoBehaviour
{
    public GameObject trig;
    Color blue = new Color(44f / 255, 130f / 255, 201f / 255, 1);
    Color yellow = new Color(254f / 255, 241f / 255, 96f / 255, 1);
    Color red = new Color(219f / 255, 10f / 255, 91f / 255, 1);
    Color green = new Color(46f / 255, 204f / 255, 113f / 255, 1);
    Color purple = new Color(145f / 255, 61f / 255, 136f / 255, 1);

    public Text number;
    int value;
    int[] listOfPrimes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
    int[] listOfSquares = { 0, 1, 4, 9, 16, 25, 36, 49, 64, 81 };
    enum conditions
    {
        odd,
        even,
        prime,
        perfectSquare,
        divisibleBy3
    }
    conditions currentCondition;
    /// Integer to string ///
    string itos(int value)
    {
        string num = value.ToString();
        if (value < 10)
            num = "0" + num;
        return num;
    }

    bool isPrime(int value)
    {
        return (listOfPrimes.Contains(value));
    }

    bool isPerfectSquare(int value)
    {
        return listOfSquares.Contains(value);
    }

    public void init()
    {
        value = Random.Range(0, 100);
        number.text = itos(value);
        currentCondition = (conditions)Random.Range(0, 5);
        switch (currentCondition)
        {
            case conditions.odd:
                number.color = blue;
                break;
            case conditions.even:
                number.color = yellow;
                break;
            case conditions.prime:
                number.color = red;
                break;
            case conditions.perfectSquare:
                number.color = green;
                break;
            case conditions.divisibleBy3:
                number.color = purple;
                break;
        }
    }

    void Start()
    {
        init();
    }
    
    void Pass()
    {
        trig.GetComponent<PuzzleController>().PuzzleSolved(1);
    }

    void Fail()
    {
        trig.GetComponent<PuzzleController>().PuzzleFailed(1);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            value--;
            if (value < 0)
            {
                value = 0;
            }
            number.text = itos(value);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            value++;
            if (value > 99)
            {
                value = 99;
            }
            number.text = itos(value);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentCondition == conditions.odd)
            {
                if ((value & 1) == 1)
                {
                    // Success
                    Pass();
                }
                else
                {
                    // Wrong
                    Fail();
                }
            }
            if (currentCondition == conditions.even)
            {
                if ((value & 1) == 0)
                {
                    // Success
                    Pass();
                }
                else
                {
                    // Wrong
                    Fail();
                }
            }
            if (currentCondition == conditions.prime)
            {
                if (isPrime(value))
                {
                    // Success
                    Pass();
                }
                else
                {
                    // Wrong
                   Fail();
                }
            }
            if (currentCondition == conditions.perfectSquare)
            {
                if (isPerfectSquare(value))
                {
                    // Success
                    Pass();
                }
                else
                {
                    // Wrong
                    Fail();
                }
            }
            if (currentCondition == conditions.divisibleBy3)
            {
                if (value % 3 == 0)
                {
                    // Success
                    Pass();
                }
                else
                {
                    // Wrong
                    Fail();
                }
            }
        }
    }
}
