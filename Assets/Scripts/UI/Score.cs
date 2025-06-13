using TMPro;
using UnityEngine;

[RequireComponent (typeof(TextMeshProUGUI))]
public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    private int _currentScore;
    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        Instance = this;
        _textMeshPro = GetComponent<TextMeshProUGUI>();
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
        _textMeshPro.text = "Ñ÷¸ò: " + _currentScore.ToString();
}
