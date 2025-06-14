using UnityEngine;

public class ProcessActivator : MonoBehaviour
{
    public void DeActivate()
    {
        WordGenerator.Instance.StopValidate();
        Timer.Instance.StopTimer();
        Bully.Instance.StopAllCoroutines();
    }
    public void Activate()
    {
        WordGenerator.Instance.StartValidate();
        Timer.Instance.StartTimer();
        Bully.Instance.StartThrowing();
    }

    public void DeactivateGO()
    {
        gameObject.SetActive(false);
    }
}
