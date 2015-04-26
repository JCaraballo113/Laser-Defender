using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Text ScoreText;

    private bool _gameOver = false;
    private static int _score = 1000;

    void Start()
    {
        ScoreText.text = "Score: " + _score;
    }

    public void UpdateScore(int points)
    {
        _score += points;
        ScoreText.text = "Score: " + _score;
    }

    public static int GetScore()
    {
        return _score;
    }

    public static void ResetScore()
    {
        _score = 0;
    }

    public void GameOver()
    {
        _gameOver = true;
        StartCoroutine("LoadNextLevel");
    }

    public bool IsGameOver()
    {
        return _gameOver;
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
