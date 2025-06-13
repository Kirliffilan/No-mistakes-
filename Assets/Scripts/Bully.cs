using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Bully : MonoBehaviour
{
    public static Bully Instance { get; private set; }

    [SerializeField] private float _maxCooldown = 10f;
    [SerializeField] private float _minCooldown = 3f;

    private float _currentCooldown;

    private Animator _animator;
    private const string LAUGH = "Laugh";
    private const string THROW = "Throw";

    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
        _currentCooldown = _maxCooldown;
        StartCoroutine(ThrowMud());
    }

    public void ReduceCooldown()
    {
        if (_currentCooldown <= _minCooldown) return;
        Debug.Log(_currentCooldown);
        _currentCooldown -= 1;
    }

    private IEnumerator ThrowMud()
    {
        while (true)
        {
            yield return new WaitForSeconds(_currentCooldown);
            //_animator.SetTrigger(THROW);
            Throw();
        }
    }

    public void Throw()
    {
        Word.Instance.GetRandomMud();
    }
}
