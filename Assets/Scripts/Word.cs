using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour
{
    [SerializeField] public List<Letter> _WordLetters;
    [SerializeField] public List<DragableLetter> _dragableLetters;
}
