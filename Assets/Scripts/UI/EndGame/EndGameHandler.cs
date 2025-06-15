using UnityEngine;

[RequireComponent(typeof(ProcessActivator))]
public class EndGameHandler : MonoBehaviour
{
    [SerializeField] GameObject _bullyLaugh;
    [SerializeField] GameObject _pauseButton;
    private ProcessActivator _processActivator;
    private void Awake()
    {
        _processActivator = GetComponent<ProcessActivator>();
    }

    private void OnEnable()
    {
        _processActivator.DeActivate();
        _bullyLaugh.SetActive(true);
        _pauseButton.SetActive(false);
    }

    private void OnDisable()
    {
        _pauseButton.SetActive(true);
        _bullyLaugh.SetActive(false);
        _processActivator.Activate();
        Score.Instance.ResetScore();
        Timer.Instance.ResetTime();
        Bully.Instance.ResetCooldown();
        HPBar.Instance.ResetHP();
    }
}
