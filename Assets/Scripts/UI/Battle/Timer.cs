using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    public static event Action EndGame;

    [SerializeField] private float _startTime = 10f;
    [SerializeField] private float _addingTime = 0.2f;

    private TextMeshProUGUI _textMeshProUGUI;
    private float _currentTime;

    private void Awake()
    {
        Instance = this;
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        ResetTime();
        EndGame += End;
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
        StartCoroutine(Tick());
    }

    public void StopTimer() => StopAllCoroutines();
    public void StartTimer() => StartCoroutine(Tick());

    private void ShowTime() => _textMeshProUGUI.text = Math.Round(_currentTime).ToString();

    private IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (_currentTime <= 0) EndGame?.Invoke();
            _currentTime -= 1;
            ShowTime();
        }
    }
    
    private void End()
    {
        StopTimer();
    }

}
