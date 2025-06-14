using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Word : MonoBehaviour
{
    public static Word Instance { get; private set; }

    public bool IsAcademy;

    private Letter[] _wordLetters;
    private bool _isCorrect;

    private const string SHOW_WORD = "ShowWord";
    private const string REMOVE_WORD = "RemoveWord";
    private Animator _animator;

    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
        _wordLetters = GetComponentsInChildren<Letter>();
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

        int i = Random.Range(0, _wordLetters.Length);
        while (_wordLetters[i].IsMuded) i = Random.Range(0, _wordLetters.Length);
        _wordLetters[i].GetMud();
    }
}
