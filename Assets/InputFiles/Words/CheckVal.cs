using System;
using UnityEngine;

public class CheckVal : MonoBehaviour
{
    [SerializeField] TextAsset _textAsset;
    string[] lines;
    private void Awake()
    {
        lines = _textAsset.text.Split(new string[] { "\n", "\r", "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
        Validate();
    }

    private void Validate()
    {
        for (int i  = 0; i < lines.Length; i++)
        {
            int line = lines[i].Split().Length;
            if (line != 3)
            {
                Debug.LogError($"WTF {i+1} line {line} parts");
            }
        }
    }
}
