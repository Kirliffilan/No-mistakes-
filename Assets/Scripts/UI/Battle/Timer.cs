using System;
using System.Collections;
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

    public void AddTime() //добавление к таймеру при правильном слове
    {
        _currentTime += _addingTime;
        ShowTime();
    }

    public void ResetTime() //возврат времени при проигрыше
    {
        _currentTime = _startTime;
        ShowTime();
    }

    public void StopTimer() => StopAllCoroutines(); //остановка таймера
    public void StartTimer() => StartCoroutine(Tick()); //запуск таймера

    private void ShowTime() => _text.text = Math.Round(_currentTime).ToString(); //показ таймера

    private IEnumerator Tick() //корутина для тика таймера(1 секунда)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (_currentTime <= 0) End();
            _currentTime -= 1;
            ShowTime();
        }
    }
    
    private void End() //если время закончилось
    {
        _endGameMenu.SetActive(true);
        StopTimer();
    }
}
