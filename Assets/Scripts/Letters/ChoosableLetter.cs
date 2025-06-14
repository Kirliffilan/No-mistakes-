using System;
using UnityEngine;

public class ChoosableLetter : Letter
{
    [SerializeField] private bool _isCorrect;
    public static event Action WrongLetter;
    public static event Action CorrectLetter;

    public bool IsPaused;

    public void OnClick()
    {
        if (IsMuded || IsPaused) return;

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
