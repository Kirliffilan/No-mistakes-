using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Teacher : MonoBehaviour
{
    public static Teacher Instance { get; private set; }

    private Animator _animator;

    private const string IS_TALKING = "IsTalking";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Instance = this;
    }

    public void StartTalking()
    {
        _animator.SetBool(IS_TALKING, true);
    }

    public void StopTalking()
    {
        _animator.SetBool(IS_TALKING, false);
    }
}
