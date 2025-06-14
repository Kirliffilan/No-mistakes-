using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextSwitcher : MonoBehaviour
{
    [SerializeField] private TextAsset _inputFile;
    [SerializeField] private GameObject _textField;
    [SerializeField] private WordScenarioGenerator _wordScenarioGenerator;

    private Text _textChange;

    private int _currentIndex;
    private string[] _text;
    private bool _isGameStarted;

    private static string MAIN_MENU = "MainMenu";

    private void Awake()
    {
        _textChange = GetComponent<Text>();
        _currentIndex = 0;
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
        if (_currentIndex == _text.Length)
        {
            SceneManager.LoadScene(MAIN_MENU);
            return;
        }
        _isGameStarted = false;
        Teacher.Instance.StartTalking();
        _textChange.text = _text[_currentIndex++];
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
