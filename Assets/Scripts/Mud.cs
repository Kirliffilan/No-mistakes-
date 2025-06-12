using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Mud : MonoBehaviour
{
    [SerializeField] private int _maxHp;
    private int _currentHp;

    public event Action MudDisabled;
    private Animator _animator;

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

    private void OnMouseDown()
    {
        _currentHp--;
        if (_currentHp < 0) gameObject.SetActive(false);
    }
}
