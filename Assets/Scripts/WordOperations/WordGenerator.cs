using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    public static WordGenerator Instance;

    [SerializeField] Word[] words;
    private Word currentWord;

    private void Awake()
    {
        Instance = this;
    }

    public void GetRandomWord()
    {
        GetWordAt(Random.Range(0, words.Length));
    }

    public void GetWordAt(int index)
    {
        if (index < 0 || index >= words.Length)
        {
            Debug.LogError($"Index {index} is out of bounds for words array!");
            return;
        }

        if (currentWord != null && currentWord.gameObject != null)
        {
            Destroy(currentWord.gameObject);
        }

        currentWord = Instantiate(words[index], transform);
    }
}