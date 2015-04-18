using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float health = 300f;

    void OnTriggerEnter2D(Collider2D other)
    {
        Projectile laser = other.gameObject.GetComponent<Projectile>();

        if (laser)
        {
            health -= laser.GetDamage();

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
