using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Mud : MonoBehaviour
{
    [SerializeField] private int _maxHp;
    private int _currentHp;

    public event Action MudDisabled;

    private Animator _animator;
    const string BREAK_MUD = "BreakMud";
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _currentHp = _maxHp;
    }

    private void OnDisable()
    {
        MudDisabled?.Invoke();
    }

    public void OnClick()
    {
        _currentHp--;
        if (_currentHp < 0) _animator.SetTrigger(BREAK_MUD);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
