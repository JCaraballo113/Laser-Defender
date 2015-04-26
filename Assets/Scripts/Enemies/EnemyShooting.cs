using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
    public GameObject LaserPrefab;
    public float LaserSpeed = 20f;
    public AudioClip ShotAudioClip;
    public float LaserDamage = 10f;
    public  float _fireRate = 0.5f;

    private GameManager _gameManager;


    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    void Update()
    {
        float probability = Time.deltaTime*_fireRate;

        if (!_gameManager.IsGameOver())
        {
            if (Random.value < probability)
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        AudioSource.PlayClipAtPoint(ShotAudioClip,transform.position);
        GameObject enemyLaser = Instantiate(LaserPrefab, transform.position, Quaternion.identity) as GameObject;
        if (enemyLaser)
        {
            enemyLaser.GetComponent<Projectile>().SetDamage(LaserDamage);
            enemyLaser.rigidbody2D.velocity = new Vector2(0f,-LaserSpeed);
        }
    }
}
