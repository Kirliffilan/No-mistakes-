using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowAnswers : MonoBehaviour
{
    [SerializeField] private TextAsset _inputFile;
    [SerializeField] private GameObject _textField;
    [SerializeField] private WordScenarioGenerator _wordScenarioGenerator;

    private TextMeshProUGUI _textMeshProUGUI;

    private static int _currentIndex;
    private string[] _text;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
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
        _textMeshProUGUI.text = _text[_currentIndex];
    }

    public void RemoveText()
    {
        Teacher.Instance.StopTalking();
        _textField.SetActive(false);
    }
}
