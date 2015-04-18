using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour
{
    public Text _scoreText;

    private int _score = 0;

    void Start()
    {
        _scoreText.text = "Score: " + _score;
    }

    public void UpdateScore(int points)
    {
        _score += points;
        _scoreText.text = "Score: " + _score;
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
