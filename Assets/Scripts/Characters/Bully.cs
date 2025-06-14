using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Bully : MonoBehaviour
{
    public static Bully Instance { get; private set; }

    [SerializeField] private float _maxCooldown = 5f;
    [SerializeField] private float _minCooldown = 2f;

    private float _currentCooldown;

    private Animator _animator;
    private const string LAUGH = "Laugh";
    private const string THROW = "Throw";

    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
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

    private void Laugh()
    {
        _animator.SetTrigger(LAUGH);
    }

    public void StartThrowing() => StartCoroutine(ThrowMud());

    public void ReduceCooldown()
    {
        if (_currentCooldown <= _minCooldown) return;
        Debug.Log(_currentCooldown);
        _currentCooldown -= 1;
    }

    public void ResetCooldown()
    {
        _currentCooldown = _maxCooldown;
    }

    private IEnumerator ThrowMud()
    {
        while (true)
        {
            yield return new WaitForSeconds(_currentCooldown);
            _animator.SetTrigger(THROW);
        }
    }

    private void Throw()
    {
        Word.Instance.GetRandomMud();
    }
}
