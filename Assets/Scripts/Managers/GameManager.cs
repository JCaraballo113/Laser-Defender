using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Text ScoreText;
    public GameObject Formation;
    public float SpawnDelay = 1f;
    public float delay = 0f;

    private bool _gameOver = false;
    private static int _score = 0;

    void Start()
    {
        Instantiate(Formation, transform.position, Quaternion.identity);
        ScoreText.text = "Score: " + _score;
    }

    void Update()
    {
        if (FormationController.Formation == null)
        {
            delay = Random.Range(0.5f, SpawnDelay);
            Invoke("NewFormation", delay);
        }
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

    private void NewFormation()
    {
        Instantiate(Formation, transform.position, Quaternion.identity);
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
