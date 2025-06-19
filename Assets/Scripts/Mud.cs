using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Mud : MonoBehaviour
{
    [SerializeField] private int _maxHp;
    private int _currentHp;

    public event Action MudDisabled; //событие для буквы, что она снова чистая

    private Animator _animator;
    const string BREAK_MUD = "BreakMud";

    private AudioSource _audioSource;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _currentHp = _maxHp;
        _audioSource.Play(); //проигрывание звука шлепка грязи
    }

    public void OnClick()
    {
        _currentHp--; //уменьшение количества кликов по грязи
        if (_currentHp < 0) _animator.SetTrigger(BREAK_MUD); //проигрывание анимации ломания грязи
    }

    public void Disable() //вызывается в анимации BreakMud
    {
        MudDisabled?.Invoke(); //пробуждение события
        gameObject.SetActive(false); //деактивация грязи
    }
}
