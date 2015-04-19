using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public Text HealthText;

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
                health -= laser.GetDamage();
                HealthText.text = "Health: " + health;

                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

 
}
