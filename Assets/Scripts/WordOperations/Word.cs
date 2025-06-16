using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Word : MonoBehaviour
{
    public static Word Instance { get; private set; }

    public bool IsAcademy;

    private List<Letter> _wordLetters = new();
    private bool _isCorrect;

    private Animator _animator;
    private const string SHOW_WORD = "ShowWord";
    private const string REMOVE_WORD = "RemoveWord";

    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
        _wordLetters.AddRange(GetComponentsInChildren<Letter>());
    }

    private void OnEnable()
    {
        ChoosableLetter.CorrectLetter += MarkAsCorrect;
        ChoosableLetter.CorrectLetter += CheckMud;
        _animator.SetTrigger(SHOW_WORD);
    }

    private void OnDisable()
    {
        ChoosableLetter.CorrectLetter -= MarkAsCorrect;
        ChoosableLetter.CorrectLetter -= CheckMud;
        _animator.SetTrigger(REMOVE_WORD);
    }

    public void AddLetter(Letter letter)
    {
        _wordLetters.Add(letter);
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
        _animator.SetTrigger(REMOVE_WORD);
    }

    private void DoNext()
    {
        if (IsAcademy)
        {
            WordScenarioGenerator.Instance.GetNewWord();
        }
        else
        {
            WordGenerator.Instance.GetNewWord();
            Score.Instance.AddScore();
            Timer.Instance.AddTime();
        }
    }

    public void GetRandomMud()
    {
        bool haveNotMuded = false;
        foreach (Letter letter in _wordLetters)
        {
            if (!letter.IsMuded)
            {
                haveNotMuded = true;
                break;
            }
        }
        if (!haveNotMuded) return;

        int i = Random.Range(0, _wordLetters.Count);
        while (_wordLetters[i].IsMuded) i = Random.Range(0, _wordLetters.Count);
        _wordLetters[i].GetMud();
    }
}
