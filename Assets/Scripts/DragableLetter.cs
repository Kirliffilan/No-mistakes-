using UnityEngine;

public class DragableLetter : Letter
{
    char Letter => _letter;
    private void OnMouseDrag()
    {
        //�������� �� ������� ���� (����� ����� ��������)
    }

    public override bool Validate() => true; //��� �� ������ ������, ���� ��� ����� ���� ������ ��������� (����� �� ����)
}
