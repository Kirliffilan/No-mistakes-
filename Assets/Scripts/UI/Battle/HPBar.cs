using System;
using Unity.VisualScripting;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    public static HPBar Instance {  get; private set; }
    public static event Action EndGame;

    [SerializeField] GameObject[] HPs;
    private int _currentIndex;

    private void Awake()
    {
        Instance = this;
        ChoosableLetter.WrongLetter += HPdown;
    }

    public void HPdown()
    {
        HPs[_currentIndex++].SetActive(false);
        if (_currentIndex == HPs.Length) EndGame?.Invoke();
    }

    public void ResetHP()
    {
        _currentIndex = 0;
        foreach(var HP  in HPs)
        {
            HP.SetActive(true);
        }
    }
}
