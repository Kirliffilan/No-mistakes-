using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(AudioSource))]
public class TextSwitcher : MonoBehaviour
{
    [SerializeField] private TextAsset _inputFile;
    [SerializeField] private GameObject _textField;
    [SerializeField] private WordScenarioGenerator _wordScenarioGenerator;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private AudioClip[] _audioClips;

    private Text _textChange;
    private AudioSource _audioSource;

    private int _currentIndex;
    private string[] _text;
    private bool _isGameStarted;

    private static readonly string MAIN_MENU = "MainMenu";

    private void Awake()
    {
        _textChange = GetComponent<Text>();
        _audioSource = GetComponent<AudioSource>();
        OnRectTransformDimensionsChange();
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
        PlayAudio();
        _textChange.text = _text[_currentIndex++];
    }

    private void PlayAudio()
    {
        _audioSource.Stop();
        _audioSource.clip = _audioClips[_currentIndex];
        _audioSource.Play();
    }

    private void StartGame()
    {
        _isGameStarted = true;

        Teacher.Instance.StopTalking();
        _wordScenarioGenerator.gameObject.SetActive(true);
        _wordScenarioGenerator.GetNewWord();
        _textField.SetActive(false);
    }

    private void OnRectTransformDimensionsChange()
    {
        if (_textChange == null || _mainCamera == null) return;

        var width = _mainCamera.pixelWidth;
        var height = _mainCamera.pixelHeight;
        if (width < height || width/height == 16/9)
        {
            _textChange.fontSize = 70;
        }
        else
        {
            _textChange.fontSize = 45;
        }
    }
}
