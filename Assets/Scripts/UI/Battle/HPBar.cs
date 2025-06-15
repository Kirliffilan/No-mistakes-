using System;
using Unity.VisualScripting;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    public static HPBar Instance {  get; private set; }

    [SerializeField] GameObject[] HPs;
    [SerializeField] GameObject _endGameMenu;
    private int _currentIndex;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        ChoosableLetter.WrongLetter += HPdown;
    }

    private void OnDisable()
    {
        ChoosableLetter.WrongLetter -= HPdown;
    }

    public void HPdown()
    {
        HPs[_currentIndex++].SetActive(false);
        if (_currentIndex == HPs.Length) _endGameMenu.SetActive(true);
    }

    public void ResetHP()
    {
        _currentIndex = 0;
        foreach(var HP in HPs)
        {
            HP.SetActive(true);
        }
    }
}
