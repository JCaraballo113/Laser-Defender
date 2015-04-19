using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100f;
    public Text HealthText;
    public AudioClip DeathClip;

    private Shields _shipShields;

    void Start()
    {
        _shipShields = GameObject.FindObjectOfType<Shields>();
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
                    AudioSource.PlayClipAtPoint(DeathClip,transform.position);
                    Destroy(gameObject);
                }
            }
        }
    }

 
}
