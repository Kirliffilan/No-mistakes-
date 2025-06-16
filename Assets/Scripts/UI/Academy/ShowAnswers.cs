using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShowAnswers : MonoBehaviour
{
    [SerializeField] private TextAsset _inputFile;
    [SerializeField] private GameObject _textField;
    [SerializeField] private WordScenarioGenerator _wordScenarioGenerator;
    [SerializeField] private Camera _mainCamera;

    private Text _textChange;

    private static int _currentIndex;
    private string[] _text;

    private void Awake()
    {
        _textChange = GetComponent<Text>();
        OnRectTransformDimensionsChange();
        _text = _inputFile.text.Split(new string[] { "\n", "\r", "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
        _currentIndex = 0;
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
