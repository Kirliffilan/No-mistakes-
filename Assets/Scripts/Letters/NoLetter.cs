using System;
using UnityEngine;

public class NoLetter : Letter
{
    [SerializeField] private char _requiredLetter;
    public static event Action WrongLetter;
    
    public override bool Validate()
    {
        if (!base.Validate()) return false;

        //логика проверки буквы + ее замена в случае правильной подстановки (исчезновение в т.ч), возвращение наводимой на место в противном случае +
        // WrongLetter?.Invoke(); //в случае неправильной буквы

        // в обоих случаях лучше вынести в методы

        return true;
    }
}
