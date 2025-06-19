using UnityEngine;

public class Letter : MonoBehaviour
{
    private bool _isMuded = false;
    public bool IsMuded => _isMuded;
    private Mud _mud;

    private void Awake()
    {
        _mud = GetComponentInChildren<Mud>(true);
    }

    private void OnEnable()
    {
        _mud.MudDisabled += BreakMud;
    }

    private void OnDisable()
    {
        _mud.MudDisabled -= BreakMud;
    }

    public void GetMud() //добавление грязи
    {
        _isMuded = true;
        _mud.gameObject.SetActive(true);
    }

    public void BreakMud() //удаление грязи
    {
        _isMuded = false;
        Word.Instance.CheckMud();
    }
}
