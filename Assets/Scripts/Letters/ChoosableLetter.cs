using System;
using UnityEngine;

public class ChoosableLetter : Letter
{
    [SerializeField] private bool _isCorrect;
    public static event Action WrongLetter;
    public static event Action CorrectLetter;

    public void MarkAsCorrect()
    {
        _isCorrect = true;
    }

    public void OnClick()
    {
        if (IsMuded) return;

        if (_isCorrect)
        {
            CorrectLetter?.Invoke();
        }
        else
        {
            WrongLetter?.Invoke();
        }
    }
}
