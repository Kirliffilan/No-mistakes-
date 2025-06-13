using System;
using UnityEngine;

public class ChoosableLetter : Letter
{
    [SerializeField] private bool _isCorrect;
    public static event Action WrongLetter;

    public bool IsPaused;

    public void OnClick()
    {
        if (IsMuded || IsPaused) return;

        if (_isCorrect)
        {
            Word.Instance.MarkAsCorrect();
            Word.Instance.CheckMud();
        }
        else
        {
            WrongLetter?.Invoke();
        }
    }

    public override bool Validate() => true; //это на всякий случай, если эти буквы тоже будете проверять (лучше не надо)
}
