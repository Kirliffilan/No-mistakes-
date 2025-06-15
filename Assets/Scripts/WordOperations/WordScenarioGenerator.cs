using UnityEngine;

public class WordScenarioGenerator : MonoBehaviour
{
    public static WordScenarioGenerator Instance { get; private set; }

    [SerializeField] private Word[] _words;
    [SerializeField] private GameObject _correctText;
    [SerializeField] private GameObject _wrongText;
    [SerializeField] private AudioSource _correctAnswer;

    private int _currentIndex;
    private bool _isPlayed;

    private Word _currentWord;


    private void Awake()
    {
        Instance = this;
        _isPlayed = false;
        _currentIndex = 0;
    }

    private void OnEnable()
    {
        ChoosableLetter.WrongLetter += ShowTip;
    }

    private void OnDisable()
    {
        ChoosableLetter.WrongLetter -= ShowTip;
    }

    private void ShowTip()
    {
        _wrongText.SetActive(true);
        gameObject.SetActive(false);
    }

    private void ShowEnd()
    {
        _isPlayed = false;
        _correctText.SetActive(true);
        gameObject.SetActive(false);
    }

    public void GetNewWord()
    {
        if (_isPlayed)
        {
            _correctAnswer.Play();
            ShowEnd();
            return;
        }

        GetWordAt(_currentIndex++);
        if (_currentIndex >= _words.Length)
        {
            _currentWord.GetRandomMud();
            _currentWord.GetRandomMud();
            _currentWord.GetRandomMud();
            _currentWord.GetRandomMud();
        }
        _isPlayed = true;
    }

    private void GetWordAt(int index)
    {
        if (index < 0 || index >= _words.Length)
        {
            Debug.LogError($"Index {index} is out of bounds for words array!");
            return;
        }

        if (_currentWord != null && _currentWord.gameObject != null)
        {
            Destroy(_currentWord.gameObject);
        }

        _currentWord = Instantiate(_words[index], transform);
        _currentWord.IsAcademy = true;
    }
}
