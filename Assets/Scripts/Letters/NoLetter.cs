using System;
using UnityEngine;

public class NoLetter : Letter
{
    [SerializeField] private char _requiredLetter;
    public static event Action WrongLetter;
    
    public override bool Validate()
    {
        if (!base.Validate()) return false;

        //������ �������� ����� + �� ������ � ������ ���������� ����������� (������������ � �.�), ����������� ��������� �� ����� � ��������� ������ +
        // WrongLetter?.Invoke(); //� ������ ������������ �����

        // � ����� ������� ����� ������� � ������

        return true;
    }
}
