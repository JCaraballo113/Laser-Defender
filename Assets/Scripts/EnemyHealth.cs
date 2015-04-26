using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 100f;
    public short killPoints = 150;
    public AudioClip DeathClip;
    public GameObject DeathExplosion;

    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
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
                _gameManager.UpdateScore(killPoints);
                Instantiate(DeathExplosion, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(DeathClip,transform.position);
                Destroy(gameObject);
            }
        }
    }
}
