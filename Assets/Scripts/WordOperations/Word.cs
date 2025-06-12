using System.Linq;
using UnityEngine;

public class Word : MonoBehaviour
{
    public Letter[] WordLetters { get; private set; }

    private void Awake()
    {
        WordLetters = GetComponentsInChildren<Letter>();
    }

    public void CheckMud()
    {
        bool check = false;
        while (!check)
        {
            check = true;
            foreach (Letter letter in WordLetters.Where(l => l is not DragableLetter))
            {
                if (letter.IsMuded) check = false;
                break;
            }
        }
        Destroy(gameObject);
    }
}
