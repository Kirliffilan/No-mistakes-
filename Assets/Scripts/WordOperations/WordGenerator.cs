using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    [SerializeField] Word[] words;
    private Word currentWord;
    public void GetRandomWord()
    {
        GetWordAt(Random.Range(0, words.Length));
    }

    public void GetWordAt(int index)
    {
        if (currentWord != null) Destroy(currentWord);
        currentWord = Instantiate(words[index]);
    }
}
