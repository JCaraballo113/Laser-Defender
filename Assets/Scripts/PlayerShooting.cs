using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public GameObject laser;
    public AudioClip LaserFX;
    public float LaserSpeed = 30f;
    public float FireRate = 0.2f;

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
            laserInstance.rigidbody2D.velocity = new Vector2(0f, LaserSpeed);
        }
    }
}
