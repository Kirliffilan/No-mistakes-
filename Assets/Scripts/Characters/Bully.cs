using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Bully : MonoBehaviour
{
    public static Bully Instance { get; private set; }

    [SerializeField] private float _maxCooldown = 5f;
    [SerializeField] private float _minCooldown = 2f;

    private float _currentCooldown;

    private Animator _animator;
    private const string LAUGH = "Laugh";
    private const string THROW = "Throw";
    
    private AudioSource _audioSource;

    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        ResetCooldown();
        StartThrowing();
    }

    private void OnEnable()
    {
        ChoosableLetter.WrongLetter += Laugh;
    }

    private void OnDisable()
    {
        ChoosableLetter.WrongLetter -= Laugh;
    }

    private void Laugh() //проигрыватель анимации смеха при неправильной букве
    {
        _animator.SetTrigger(LAUGH);
        _audioSource.Play();
    }

    public void StartThrowing() => StartCoroutine(ThrowMud()); //начинает корутину для бросков грязью

    public void ReduceCooldown() //уменьшает кулдаун броска
    {
        if (_currentCooldown <= _minCooldown) return;

        _currentCooldown -= 1;
    }

    public void ResetCooldown() //возвращает исходный кулдаун при проигрыше
    {
        _currentCooldown = _maxCooldown;
    }

    private IEnumerator ThrowMud()
    {
        while (true)
        {
            yield return new WaitForSeconds(_currentCooldown); //зависит от текущего кулдауна
            _animator.SetTrigger(THROW); //анимация броска
        }
    }

    private void Throw() //активируется в анимации броска
    {
        Word.Instance.GetRandomMud();
    }
}
