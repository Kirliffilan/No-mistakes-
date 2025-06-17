using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Mud : MonoBehaviour
{
    [SerializeField] private int _maxHp;
    private int _currentHp;

    public event Action MudDisabled;

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
        _audioSource.Play();
    }

    public void OnClick()
    {
        _currentHp--;
        if (_currentHp < 0) _animator.SetTrigger(BREAK_MUD);
    }

    public void Disable()
    {
        MudDisabled?.Invoke();
        gameObject.SetActive(false);
    }
}
