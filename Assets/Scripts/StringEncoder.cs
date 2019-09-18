using System.Text;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StringEncoder : MonoBehaviour
{
    public GameObject trig;
    public PuzzleContro2 Player;
    public RayCastClick rayer;

    private static System.Random random = new System.Random();
    public Text strEncoded, strDecoded;
    private string encoded, decoded;

    Condition curr;

    enum Condition
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

    bool AllSame(string str)
    {
        return str.Distinct().Count() == 1;
    }

    bool Any3Same(string str)
    {
        return (str.Count(x => x == 'A') == 3 || str.Count(x => x == 'B') == 3 || str.Count(x => x == 'C') == 3 || str.Count(x => x == 'D') == 3);
    }

    bool Any2Same(string str)
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

    Condition CurrCondition()
    {
        Condition curr;
        if (AllSame(encoded))
        {
            curr = Condition.allSame;
        }
        else if (Any3Same(encoded))
        {
            curr = Condition.any3Same;
        }
        else if (Any2Same(encoded))
        {
            curr = Condition.any2Same;
        }
        else if (LexicographicallySorted(encoded))
        {
            curr = Condition.LexicographicallySorted;
        }
        else if (ReverseSorted(encoded))
        {
            curr = Condition.ReverseSorted;
        }
        else
        {
            curr = Condition.allDifferent;
        }
        return curr;
    }

    bool AllSameResult()
    {
        return (encoded[0] == 'A' && decoded[0] == 'B' && AllSame(decoded)) ||
            (encoded[0] == 'B' && decoded[0] == 'C' && AllSame(decoded)) ||
            (encoded[0] == 'C' && decoded[0] == 'D' && AllSame(decoded)) ||
            (encoded[0] == 'D' && decoded[0] == 'A' && AllSame(decoded))
            ;
    }

    bool Any3SameResult()
    {
        return (encoded.Count(x => x == 'A') == 1 && decoded[0] == 'A' && AllSame(decoded)) ||
            (encoded.Count(x => x == 'B') == 1 && decoded[0] == 'B' && AllSame(decoded)) ||
            (encoded.Count(x => x == 'C') == 1 && decoded[0] == 'C' && AllSame(decoded)) ||
            (encoded.Count(x => x == 'D') == 1 && decoded[0] == 'D' && AllSame(decoded));
    }

    bool Any2SameResult()
    {
        return (encoded.Count(x => x == 'A') == 0 && decoded[0] == 'A' && AllSame(decoded)) ||
            (encoded.Count(x => x == 'B') == 0 && decoded[0] == 'B' && AllSame(decoded)) ||
            (encoded.Count(x => x == 'C') == 0 && decoded[0] == 'C' && AllSame(decoded)) ||
            (encoded.Count(x => x == 'D') == 0 && decoded[0] == 'D' && AllSame(decoded));
    }

    bool LexicallySortedResult()
    {
        return decoded == "DCBA";
    }

    bool ReverseSortedResult()
    {
        return true; // You got lucky, 1 in 256
    }

    bool AllDifferentResult()
    {
        return decoded[0] == encoded[2] && decoded[1] == encoded[3]
            && decoded[2] == encoded[0] && decoded[3] == encoded[1];
    }

    bool CheckResult()
    {
        switch (curr)
        {
            case Condition.allSame:
                return AllSameResult();
            case Condition.any3Same:
                return Any3SameResult();
            case Condition.any2Same:
                return Any2SameResult();
            case Condition.LexicographicallySorted:
                return LexicallySortedResult();
            case Condition.ReverseSorted:
                return ReverseSortedResult();
            case Condition.allDifferent:
                return AllDifferentResult();
            default:
                return true;
        }
    }

    public void Init()
    {
        encoded = RandomString();
        decoded = RandomString();
        strEncoded.text = encoded;
        strDecoded.text = decoded;
        curr = CurrCondition();
    }

    void Start()
    {
        Init();
    }

    int currRow = 0;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (CheckResult())
            {
                // Success
                Player.PuzzleSolved(1);
            }
            else
            {
                // Fail
                Player.PuzzleFailed(1);
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

