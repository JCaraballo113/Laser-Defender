using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
    public GameObject LaserPrefab;
    public float LaserSpeed = 20f;
    public AudioClip ShotAudioClip;

    private float _fireRate = 0.5f;


    void Update()
    {
        float probability = Time.deltaTime*_fireRate;

        if (Random.value < probability)
        {
            Fire();
        }
    }

    void Fire()
    {
        AudioSource.PlayClipAtPoint(ShotAudioClip,transform.position);
        GameObject enemyLaser = Instantiate(LaserPrefab, transform.position, Quaternion.identity) as GameObject;
        if (enemyLaser) enemyLaser.rigidbody2D.velocity = new Vector2(0f,-LaserSpeed);
    }
}
