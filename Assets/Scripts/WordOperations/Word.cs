using System.Linq;
using UnityEngine;

public class Word : MonoBehaviour
{
    public static Word Instance { get; private set; }
    private Letter[] _wordLetters;
    private bool _isCorrect;
    
    private void Awake()
    {
        Instance = this;
        _wordLetters = GetComponentsInChildren<Letter>();
    }

    public void StopValidate()
    {
        foreach (Letter letter in _wordLetters)
        {
            if (letter is ChoosableLetter cl) cl.IsPaused = true;
        }
    }

    public void StartValidate()
    {
        foreach (Letter letter in _wordLetters)
        {
            if (letter is ChoosableLetter cl) cl.IsPaused = false;
        }
    }

    public void MarkAsCorrect()
    {
        _isCorrect = true;
    }

    public void CheckMud()
    {
        if (!_isCorrect) return;
        foreach (Letter letter in _wordLetters.Where(l => l is not ChoosableLetter))
            if (letter.IsMuded) return;
        Score.Instance.AddScore();
        Timer.Instance.AddTime();
        WordGenerator.Instance.GetNewWord();
    }

    public void GetRandomMud()
    {
        int i = Random.Range(0, _wordLetters.Length);
        while (_wordLetters[i].IsMuded) i = Random.Range(0, _wordLetters.Length);
        _wordLetters[i].GetMud();
    }
}
