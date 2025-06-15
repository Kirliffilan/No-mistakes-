using UnityEngine;

public class ProcessActivator : MonoBehaviour
{
    public void DeActivate()
    {
        WordGenerator.Instance.StopValidate();
        Timer.Instance.StopAllCoroutines();
        Bully.Instance.StopAllCoroutines();

        WordGenerator.Instance.gameObject.SetActive(false);
        Timer.Instance.gameObject.SetActive(false);
        Bully.Instance.gameObject.SetActive(false);
        HPBar.Instance.gameObject.SetActive(false);
        Score.Instance.gameObject.SetActive(false);
    }
    public void Activate()
    {
        WordGenerator.Instance.gameObject.SetActive(true);
        Timer.Instance.gameObject.SetActive(true);
        Bully.Instance.gameObject.SetActive(true);
        HPBar.Instance.gameObject.SetActive(true);
        Score.Instance.gameObject.SetActive(true);

        WordGenerator.Instance.StartValidate();
        Timer.Instance.StartTimer();
        Bully.Instance.StartThrowing();
    }

    public void DeactivateGO()
    {
        gameObject.SetActive(false);
    }
}
