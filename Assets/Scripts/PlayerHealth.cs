using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100f;
    public Text HealthText;
    public AudioClip DeathClip;
    public AudioClip HitClip;
    public GameObject DeathExplosion;

    private Shields _shipShields;
    private GameManager _gameManager;

    void Start()
    {
        _shipShields = GameObject.FindObjectOfType<Shields>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Projectile laser = other.gameObject.GetComponent<Projectile>();

        if (laser)
        {
            if (!_shipShields.ShieldsUp)
            {
                _shipShields._shieldTimer = 0f;
                Health -= laser.GetDamage();
                HealthText.text = "Health: " + Health;

                if (Health <= 0)
                {
                    _gameManager.GameOver();
                    Instantiate(DeathExplosion, transform.position, Quaternion.identity);
                    AudioSource.PlayClipAtPoint(DeathClip,transform.position);
                    Destroy(gameObject);
                }
            }
        }
    }

 
}
