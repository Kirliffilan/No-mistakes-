using UnityEngine;

public class DragableLetter : Letter
{
    [SerializeField] private char _letter;
    public char Letter => _letter;
    private void OnMouseDrag()
    {
        //�������� �� ������� ���� (����� ����� ��������)
    }

    public override bool Validate() => true; //��� �� ������ ������, ���� ��� ����� ���� ������ ��������� (����� �� ����)
}
