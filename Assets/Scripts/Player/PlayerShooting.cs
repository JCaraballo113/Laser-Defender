using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public GameObject laser;
    public AudioClip LaserFX;
    public float LaserSpeed = 30f;
    public float FireRate = 0.2f;
    public float LaserDamage = 0f;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("Fire");
        }

        if(Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("Fire",0.001f,FireRate);
        }
    }


    void Fire()
    {
        AudioSource.PlayClipAtPoint(LaserFX,transform.position);
        GameObject laserInstance = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;

        if (laserInstance)
        {
            Projectile projectile = laserInstance.GetComponent<Projectile>();
            projectile.transform.parent = this.transform;
            projectile.SetDamage(LaserDamage);
            laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, LaserSpeed);
        }
    }
}
