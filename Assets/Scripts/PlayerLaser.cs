using UnityEngine;
using System.Collections;

public class PlayerLaser : MonoBehaviour
{
    private int _laserDamage = 1;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Enemy")
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.Damage(_laserDamage);
            Destroy(gameObject);
        }
    }
}
