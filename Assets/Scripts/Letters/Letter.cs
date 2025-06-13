using UnityEngine;

public class Letter : MonoBehaviour
{
    private bool _isMuded = false;
    public bool IsMuded => _isMuded;
    private Mud _mud;

    private void Awake()
    {
        _mud = GetComponentInChildren<Mud>(true);
        _mud.MudDisabled += BreakMud;
    }

    public void GetMud()
    {
        _isMuded = true;
        _mud.gameObject.SetActive(true);
    }

    public void BreakMud()
    {
        _isMuded = false;
        Word.Instance.CheckMud();
    }

    public virtual bool Validate()
    {
        if (_isMuded) return false;
        return true;
    }
}
