using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextSwitcher : MonoBehaviour
{
    [SerializeField] private TextAsset _inputFile;
    [SerializeField] private GameObject _textField;
    [SerializeField] private WordScenarioGenerator _wordScenarioGenerator;

    private TextMeshProUGUI _textMeshProUGUI;

    private int _currentIndex;
    private string[] _text;
    private bool _isGameStarted;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _text = _inputFile.text.Split(new string[] { "\n", "\r", "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
        ChangeText();
    }

    public void ChangeText()
    {
        if (_currentIndex % 3 == 0 && !_isGameStarted && _currentIndex != 0)
        {
            StartGame();
            return;
        }
        _isGameStarted = false;
        Teacher.Instance.StartTalking();
        _textMeshProUGUI.text = _text[_currentIndex++];
    }

    private void StartGame()
    {
        _isGameStarted = true;

        Teacher.Instance.StopTalking();
        _wordScenarioGenerator.gameObject.SetActive(true);
        _wordScenarioGenerator.GetNewWord();
        _textField.SetActive(false);
    }
}
