using System.Text;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StringEncoder : MonoBehaviour
{

    public GameObject trig;
    public PuzzleContro2 Player;
    public RayCastClick rayer;
    public GameObject[] Characters; // ABCD
    public Transform[] DrawCharacterTransform;
    private GameObject[] DecodedCharacters = new GameObject[4];
    private GameObject TempObj;
    public Mesh[] MeshArray;

    int currRow = 0;


    private static System.Random random = new System.Random();
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
        decoded = "DBBC";
        Create3DText(encoded, 0);
        Create3DText(decoded, 4);
        curr = CurrCondition();
        PlaceSetter();
    }

    void Create3DText(string str, int pos) // pos for left or right string
    {
        int k = 0;
        for (int i = 0; i < 4; ++i)
        {
            int ind = str[i] - 'A';
            if (k == 4) k = 0;
            if (pos == 4)
            {
                if (DecodedCharacters[k] == null)
                {
                    DecodedCharacters[k] = Instantiate(Characters[ind], DrawCharacterTransform[i + pos].position, Quaternion.Euler(0, 180, 0));
                }
                else
                {
                    Destroy(DecodedCharacters[k]);
                    DecodedCharacters[k] = Instantiate(Characters[ind], DrawCharacterTransform[i + pos].position, Quaternion.Euler(0, 180, 0));
                }
                k++;
            }
            else
            {
                Instantiate(Characters[ind], DrawCharacterTransform[i].position, Quaternion.Euler(0, 180, 0));
            }
        }
    }
   
    void PlaceSetter()
    {
        for (int i = 0; i < 4; ++i)
            DecodedCharacters[i].GetComponent<StringEncoderBlock>().place = i;
    }

    void Start()
    {
        Init();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (rayer.RayInput() == "Submit2")
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
            int n;
            TempObj = rayer.RayReference();
            if (TempObj == null) return;
            if (TempObj.tag == "3Dmodel")
            {
                n = TempObj.GetComponent<StringEncoderBlock>().place;
                StringBuilder sb = new StringBuilder(decoded);
                sb[n] = (char)(((decoded[n] - 'A') + 1) % 4 + 65);
                Debug.Log(sb[n]);
                decoded = sb.ToString();
                Debug.Log(decoded);
                DecoderCharacterMeshChanger();
                Debug.Log("Pressed on 3dmodel");
            }
            //if (rayer.RayInput() == "Cycler") // To cycle current character
            //{

            //}
            //if (rayer.RayInput() == "NextChar") // To cycle to next row of character
            //{
            //    currRow = ++currRow % 4;
            //}
        }
    }
    void DecoderCharacterMeshChanger()
    {
        for (int i = 0; i < 4; ++i)
        {
            int index = decoded[i] - 'A';
            DecodedCharacters[i].GetComponent<MeshFilter>().mesh = MeshArray[index];
        }
    }
    void ActualStringChanger()
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
    }
}
