using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    public static WordGenerator Instance;

    [SerializeField] private bool _isRandom;
    [SerializeField] private Word[] _words;

    private Word _currentWord;
    private int _currentIndex;

    private void Awake()
    {
        Instance = this;
    }

    public void GetNewWord()
    {
        if (_isRandom) GetRandomWord();
        else GetWordAt(_currentIndex++);
    }

    private void GetRandomWord()
    {
        GetWordAt(Random.Range(0, _words.Length));
    }

    private void GetWordAt(int index)
    {
        if (index < 0 || index >= _words.Length)
        {
            if (_currentIndex == index) _currentIndex = 0; //можно заканчивать обучение в этом случае

            Debug.LogError($"Index {index} is out of bounds for words array!");
            return;
        }

        if (_currentWord != null && _currentWord.gameObject != null)
        {
            Destroy(_currentWord.gameObject);
        }

        _currentWord = Instantiate(_words[index], transform);
    }
}