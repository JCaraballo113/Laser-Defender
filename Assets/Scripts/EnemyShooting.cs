using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
    public GameObject LaserPrefab;
    public float LaserSpeed = 20f;
    public AudioClip ShotAudioClip;

    private float _timer = 0f;
    private float _fireRate = 0f;


    void Update()
    {
        _timer += Time.deltaTime;
        _fireRate = Random.Range(1f, 10f);

        if (_timer >= _fireRate)
        {
            _timer = 0f;
            Shoot();
        }
    }

    void Shoot()
    {
        AudioSource.PlayClipAtPoint(ShotAudioClip,transform.position);
        GameObject enemyLaser = Instantiate(LaserPrefab, transform.position, Quaternion.identity) as GameObject;
        if (enemyLaser) enemyLaser.rigidbody2D.velocity = new Vector2(0f,-LaserSpeed);
    }
}
