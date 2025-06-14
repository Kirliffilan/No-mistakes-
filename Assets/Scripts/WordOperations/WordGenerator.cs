using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    public static WordGenerator Instance { get; private set; }

    [SerializeField] private Word[] _words;

    private Word _currentWord;

    private void Awake()
    {
        Instance = this;
        GetNewWord();
    }

    public void StopValidate() => _currentWord.StopValidate();
    public void StartValidate() => _currentWord.StartValidate();

    public virtual void GetNewWord()
    {
        GetRandomWord();
    }

    private void GetRandomWord()
    {
        GetWordAt(Random.Range(0, _words.Length));
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
    }
}