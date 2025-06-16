using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WordGenerator : MonoBehaviour
{
    public static WordGenerator Instance { get; private set; }

    [SerializeField] private TextAsset _inputFile;

    [Header("Настройка букв")]
    [SerializeField] private float _spacing = 100;

    private static Dictionary<char, Letter> _letters = new();
    private static Dictionary<char, ChoosableLetter> _choosableLetters = new();
    private static Word _wordBase;

    private string[] _lines;

    private Word _currentWord;

    private AudioSource _audioSource;

    private void Awake()
    {
        Instance = this;
        InitPrefabs();

        _lines = _inputFile.text.Split(new string[] { "\n", "\r", "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
        _audioSource = GetComponent<AudioSource>();
        GetNewWord();
    }

    private void InitPrefabs()
    {
        _wordBase = Resources.Load<Word>("Prefabs/Word");

        if(_letters.Count > 0 && _choosableLetters.Count > 0 ) return;

        _letters['_'] = Resources.Load<Letter>($"Prefabs/Letters/_");
        _letters['ё'] = Resources.Load<Letter>($"Prefabs/Letters/Ё");

        _choosableLetters['ё'] = Resources.Load<ChoosableLetter>($"Prefabs/ChoosableLetters/Ё_");
        _choosableLetters['-'] = Resources.Load<ChoosableLetter>($"Prefabs/ChoosableLetters/-");
        
        for (char c = 'а'; c <= 'я'; c++)
        {
            _letters[c] = Resources.Load<Letter>($"Prefabs/Letters/{char.ToUpper(c)}");
            _choosableLetters[c] = Resources.Load<ChoosableLetter>($"Prefabs/ChoosableLetters/{char.ToUpper(c)}_");
        }
    }

    public void StopValidate() => _currentWord.StopValidate();
    public void StartValidate() => _currentWord.StartValidate();

    public void GetNewWord()
    {
        _audioSource.Play();
        GetRandomWord();
    }

    private void GetRandomWord()
    {
        GetWordAt(UnityEngine.Random.Range(0, _lines.Length));
    }

    private void GenerateWord(int index)
    {
        if (index < 0 || index >= _lines.Length)
        {
            Debug.LogError($"Index {index} is out of bounds for words array!");
            return;
        }

        string[] letters = _lines[index].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (letters.Length != 3)
        {
            Debug.LogError($"Invalid line format at index {index}. Expected 3 parts, got {letters.Length}");
            return;
        }

        Word word = Instantiate(_wordBase, transform);

        Vector2 upperStartPos = new(200, -400);
        for (int i = 0; i < letters[0].Length; i++)
        {
            char currentChar = letters[0][i];

            Letter letter = Instantiate(_letters[currentChar], word.transform);

            RectTransform rt = letter.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(upperStartPos.x + i * _spacing, upperStartPos.y);
            word.AddLetter(letter);
        }

        Vector2 lowerStartPos = new(200, 300);
        for (int i = 0; i < letters[2].Length; i++)
        {
            char currentChar = letters[2][i];

            ChoosableLetter letter = Instantiate(_choosableLetters[currentChar], word.transform);
            if (currentChar == letters[1][0]) letter.MarkAsCorrect();

            RectTransform rt = letter.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(lowerStartPos.x + i * _spacing, lowerStartPos.y);
            word.AddLetter(letter);
        }
        _currentWord = word;
    }

    private void GetWordAt(int index)
    {
        if (index < 0 || index >= _lines.Length)
        {
            Debug.LogError($"Index {index} is out of bounds for words array!");
            return;
        }

        if (_currentWord != null && _currentWord.gameObject != null)
        {
            Destroy(_currentWord.gameObject);
        }

        GenerateWord(index);
    }
}