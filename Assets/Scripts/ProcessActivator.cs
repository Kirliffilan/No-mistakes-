using UnityEngine;

public class ProcessActivator : MonoBehaviour
{
    public void DeActivate()
    {
        Timer.Instance.StopAllCoroutines(); //останавливает корутины
        Bully.Instance.StopAllCoroutines();

        WordGenerator.Instance.gameObject.SetActive(false); //деактивирует объекты
        Timer.Instance.gameObject.SetActive(false);
        Bully.Instance.gameObject.SetActive(false);
        HPBar.Instance.gameObject.SetActive(false);
        Score.Instance.gameObject.SetActive(false);
    }
    public void Activate()
    {
        WordGenerator.Instance.gameObject.SetActive(true); //активирует объекты
        Timer.Instance.gameObject.SetActive(true);
        Bully.Instance.gameObject.SetActive(true);
        HPBar.Instance.gameObject.SetActive(true);
        Score.Instance.gameObject.SetActive(true);

        Timer.Instance.StartTimer(); //начинает корутины
        Bully.Instance.StartThrowing();
    }

    public void DeactivateGO()
    {
        gameObject.SetActive(false);
    }
}
