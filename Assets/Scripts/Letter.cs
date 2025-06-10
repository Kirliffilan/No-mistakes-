using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] protected char _letter;
    protected bool _isMuded = false;
    public void GetMud()
    {
        _isMuded = true;
        //тут скорее всего спавн грязи будет
    }

    public void BreakMud()
    {
        _isMuded = false;
    }

    public virtual bool Validate()
    {
        if (_isMuded) return false;
        return true;
    }
}
