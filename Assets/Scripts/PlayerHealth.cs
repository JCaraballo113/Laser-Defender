using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float health = 300f;

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyProjectile laser = other.gameObject.GetComponent<EnemyProjectile>();

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
