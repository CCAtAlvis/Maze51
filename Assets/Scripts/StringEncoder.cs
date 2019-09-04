using System.Collections;
using System.Collections.Generic;
using System; // For the random class
using System.Text; // For the stringbuilder class
using System.Linq; // For the Enumeration function
using UnityEngine;
using UnityEngine.UI;

public class StringEncoder : MonoBehaviour {

    private static System.Random random = new System.Random();
    public Text strEncoded, strDecoded;
    public string encoded, decoded;

    condition curr;

    enum condition
    {
        allSame, // All same characters e.g aaaa
        any3Same, // e.g aaba or aaab
        any2Same, // e.g aabc or abbc
        LexicographicallySorted, // e.g abcd
        ReverseSorted, // e.g dcba
        allDifferent // e.g abcd or acbd
    };

    string RandomString()
    {
        int length = 4;
        const string chars = "ABCD";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    bool allSame(string str)
    {
        return str.Distinct().Count() == 1;
    }

    bool any3Same(string str)
    {
        return (str.Count(x => x == 'A') == 3 || str.Count(x => x == 'B') == 3 || str.Count(x => x == 'C') == 3 || str.Count(x => x == 'D') == 3);
    }

    bool any2Same(string str)
    {
        return (str.Count(x => x == 'A') == 2 || str.Count(x => x == 'B') == 2 || str.Count(x => x == 'C') == 2 || str.Count(x => x == 'D') == 2);
  
    }

    bool LexicographicallySorted(string str)
    {
        return str == "ABCD";
        //return (String.Concat(str.OrderBy(x => x)) == str); // Sorted string == string?
    }

    bool ReverseSorted(string str)
    {
        return str == "DCBA";
    }

    condition currCondition()
    {
        condition curr;
        if (allSame(encoded))
        {
            curr = condition.allSame;
        }
        else if(any3Same(encoded))
        {
            curr = condition.any3Same;
        }
        else if(any2Same(encoded))
        {
            curr = condition.any2Same;
        }
        else if(LexicographicallySorted(encoded))
        {
            curr = condition.LexicographicallySorted;
        }
        else if (ReverseSorted(encoded))
        {
            curr = condition.ReverseSorted;
        }
        else
        {
            curr = condition.allDifferent;
        }
        return curr;
    }

    bool allSameResult()
    {
        return (encoded[0] == 'A' && decoded[0] == 'B' && allSame(decoded)) ||
            (encoded[0] == 'B' && decoded[0] == 'C' && allSame(decoded)) ||
            (encoded[0] == 'C' && decoded[0] == 'D' && allSame(decoded)) ||
            (encoded[0] == 'D' && decoded[0] == 'A' && allSame(decoded))
            ;
    }

    bool any3SameResult()
    {
        return (encoded.Count(x => x == 'A') == 1 && decoded[0] == 'A' && allSame(decoded)) ||
            (encoded.Count(x => x == 'B') == 1 && decoded[0] == 'B' && allSame(decoded)) ||
            (encoded.Count(x => x == 'C') == 1 && decoded[0] == 'C' && allSame(decoded)) ||
            (encoded.Count(x => x == 'D') == 1 && decoded[0] == 'D' && allSame(decoded));
    }

    bool any2SameResult()
    {
        return (encoded.Count(x => x == 'A') == 0 && decoded[0] == 'A' && allSame(decoded)) ||
            (encoded.Count(x => x == 'B') == 0 && decoded[0] == 'B' && allSame(decoded)) ||
            (encoded.Count(x => x == 'C') == 0 && decoded[0] == 'C' && allSame(decoded)) ||
            (encoded.Count(x => x == 'D') == 0 && decoded[0] == 'D' && allSame(decoded));
    }

    bool LexicallySortedResult()
    {
        return decoded == "DCBA";
    }

    bool ReverseSortedResult()
    {
        return true; // You got lucky, 1 in 256
    }

    bool allDifferentResult()
    {
        return decoded[0] == encoded[2] && decoded[1] == encoded[3]
            && decoded[2] == encoded[0] && decoded[3] == encoded[1];
    }

    bool checkResult()
    {
        switch (curr)
        {
            case condition.allSame:
                return allSameResult();
            case condition.any3Same:
                return any3SameResult();
            case condition.any2Same:
                return any2SameResult();
            case condition.LexicographicallySorted:
                return LexicallySortedResult();
            case condition.ReverseSorted:
                return ReverseSortedResult();
            case condition.allDifferent:
                return allDifferentResult();
            default:
                return true;
        }
    }
    
    
	// Use this for initialization
	void Start () {
        encoded = RandomString();
        decoded = RandomString();
        strEncoded.text = encoded;
        strDecoded.text = decoded;
        curr = currCondition();
        //if (LexicographicallySorted("ABCD"))
        //    Debug.Log("Yes");
	}

    int currRow = 0;
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.D))
        {
            if (checkResult())
            {
                // Success
                Result.Success();
            }
            else
            {
                // Fail
                Result.Fail();
            }
        }
        else if (Input.GetKeyDown(KeyCode.A)) // To cycle current character
        {
            StringBuilder sb = new StringBuilder(decoded);
            if (decoded[currRow] == 'A')
                sb[currRow] = 'B';
            else if (decoded[currRow] == 'B')
                sb[currRow] = 'C';
            else if (decoded[currRow] == 'C')
                sb[currRow] = 'D';
            else if (decoded[currRow] == 'D')
                sb[currRow] = 'A';
            decoded = sb.ToString();
            strDecoded.text = decoded;
        }
        else if (Input.GetKeyDown(KeyCode.S)) // To cycle to next row of character
        {
            currRow = ++currRow % 4;
        }
	}
}

