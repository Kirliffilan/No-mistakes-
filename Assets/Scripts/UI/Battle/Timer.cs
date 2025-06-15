using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    [SerializeField] private float _startTime = 10f;
    [SerializeField] private float _addingTime = 0.2f;
    [SerializeField] private GameObject _endGameMenu;

    private Text _text;
    private float _currentTime;

    private void Awake()
    {
        Instance = this;
        _text = GetComponent<Text>();
        ResetTime();
        StartTimer();
    }


    public void AddTime()
    {
        _currentTime += _addingTime;
        ShowTime();
    }

    public void ResetTime()
    {
        _currentTime = _startTime;
        ShowTime();
    }

    public void StopTimer() => StopAllCoroutines();
    public void StartTimer() => StartCoroutine(Tick());

    private void ShowTime() => _text.text = Math.Round(_currentTime).ToString();

    private IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (_currentTime <= 0) End();
            _currentTime -= 1;
            ShowTime();
        }
    }
    
    private void End()
    {
        _endGameMenu.SetActive(true);
        StopTimer();
    }
}
