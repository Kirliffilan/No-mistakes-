using System.Linq;
using UnityEngine;

public class Word : MonoBehaviour
{
    public static Word Instance;
    private Letter[] _wordLetters;
    private bool _isCorrect;
    
    private void Awake()
    {
        Instance = this;
        _wordLetters = GetComponentsInChildren<Letter>();
    }

    public void MarkAsCorrect()
    {
        _isCorrect = true;
        Debug.Log("Slovo horosho");
    }

    public void CheckMud()
    {
        if (!_isCorrect) return;
        foreach (Letter letter in _wordLetters.Where(l => l is not ChoosableLetter))
            if (letter.IsMuded) return;
        Destroy(gameObject);
        Debug.Log("Slovo chistoe");
        WordGenerator.Instance.GetNewWord();
    }
}
