using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 300f;
    public short killPoints = 150;

    private ScoreKeeper _scoreKeeper;

    void Start()
    {
        _scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Projectile laser = other.gameObject.GetComponent<Projectile>();

        if (laser)
        {
            Health -= laser.GetDamage();
            laser.Hit();

            if (Health <= 0f)
            {
                _scoreKeeper.UpdateScore(killPoints);
                Destroy(gameObject);
            }
        }
    }
}
