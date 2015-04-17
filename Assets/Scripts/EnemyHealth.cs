using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 300f;

    private FormationController _formationController;

    void Start()
    {
        _formationController = gameObject.GetComponentInParent<FormationController>();
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
                _formationController.EnemyDestroyed();
                Destroy(gameObject);
            }
        }
    }
}
