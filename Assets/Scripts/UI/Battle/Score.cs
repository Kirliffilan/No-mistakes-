using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    private int _currentScore;
    public int CurrentScore => _currentScore;

    private Text _text;

    private void Awake()
    {
        Instance = this;
        _text = GetComponent<Text>();
        ResetScore();
    }

    public void AddScore()
    {
        _currentScore++;
        ShowScore();
        if (_currentScore % 10 == 0) Bully.Instance.ReduceCooldown();
    }

    public void ResetScore()
    {
        _currentScore = 0;
        ShowScore();
    }

    private void ShowScore() => 
        _text.text = "Ñ÷¸ò: " + _currentScore.ToString();
}
