using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShowAnswers : MonoBehaviour
{
    [SerializeField] private TextAsset _inputFile;
    [SerializeField] private GameObject _textField;
    [SerializeField] private WordScenarioGenerator _wordScenarioGenerator;

    private Text _textChange;

    private static int _currentIndex;
    private string[] _text;

    private void Awake()
    {
        _textChange = GetComponent<Text>();
        _text = _inputFile.text.Split(new string[] { "\n", "\r", "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
    }

    private void OnEnable()
    {
        ShowText();
    }

    public void AddIndex()
    {
        _currentIndex++;
    }

    public void ShowText()
    {
        Teacher.Instance.StartTalking();
        _textChange.text = _text[_currentIndex];
    }

    public void RemoveText()
    {
        Teacher.Instance.StopTalking();
        _textField.SetActive(false);
    }
}
