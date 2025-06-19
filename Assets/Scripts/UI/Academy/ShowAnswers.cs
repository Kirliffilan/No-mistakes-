using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(AudioSource))]
public class ShowAnswers : MonoBehaviour
{
    [SerializeField] private TextAsset _inputFile; //файл с репликами
    [SerializeField] private GameObject _textField; //текстовое поле
    [SerializeField] private WordScenarioGenerator _wordScenarioGenerator; //генератор слов
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private AudioClip[] _audioClips; //звучащие реплики

    private Text _textChange;
    private AudioSource _audioSource;

    private static int _currentIndex;
    private string[] _text;

    private void Awake()
    {
        _textChange = GetComponent<Text>();
        _audioSource = GetComponent<AudioSource>();
        OnRectTransformDimensionsChange();
        _text = _inputFile.text.Split(new string[] { "\n", "\r", "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
        _currentIndex = 0;
    }

    private void OnEnable()
    {
        ShowText();
    }

    public void AddIndex() //переход к следующему
    {
        _currentIndex++;
    }

    public void ShowText() //показывает текст и включает анимацию учителю
    {
        Teacher.Instance.StartTalking();
        PlayAudio();
        _textChange.text = _text[_currentIndex];
    }

    private void PlayAudio() //воспроизводит текущую реплику
    {
        _audioSource.Stop();
        _audioSource.clip = _audioClips[_currentIndex];
        _audioSource.Play();
    }

    public void RemoveText() //деактивирует текст и отключает анимацию учителя
    {
        Teacher.Instance.StopTalking();
        _textField.SetActive(false);
    }
    private void OnRectTransformDimensionsChange()
    {
        if (_textChange == null || _mainCamera == null) return;

        var width = _mainCamera.pixelWidth;
        var height = _mainCamera.pixelHeight;

        if (width / height == 16 / 9)
        {
            _textChange.fontSize = 70;
        }
        else if (width < height)
        {
            _textChange.fontSize = 70;
        }
        else
        {
            _textChange.fontSize = 45;
        }
    }
}
