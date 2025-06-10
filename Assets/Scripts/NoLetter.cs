using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoLetter : Letter
{
    [SerializeField] private char _requiredLetter;
    private char _letter = '_';

    public override bool Validate()
    {
        if (!base.Validate()) return false;

        //логика проверки буквы

        return true;
    }
}
