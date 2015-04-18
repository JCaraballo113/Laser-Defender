using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 300f;

    void OnTriggerEnter2D(Collider2D other)
    {
        Projectile laser = other.gameObject.GetComponent<Projectile>();

        if (laser)
        {
            Health -= laser.GetDamage();
            laser.Hit();

            if (Health <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
