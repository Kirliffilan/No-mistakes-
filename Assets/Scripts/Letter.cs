using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private char _letter;
    private bool _isMuded = false;
    private void GetMud()
    {
        _isMuded = true;
        //��� ������ ����� ����� ����� �����
    }

    private void BreakMud()
    {
        _isMuded = false;
    }

    public virtual bool CheckValidate()
    {
        if (_isMuded) return false;
        return true;
    }
}
