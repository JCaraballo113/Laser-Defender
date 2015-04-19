using UnityEngine;
using System.Collections;

public class Shields : MonoBehaviour
{
    public AudioClip ShieldsUpSFX;
    public AudioClip ShieldsDownSFX;
    public AudioClip ShieldsHitSFX;
    public float ShieldRechargeTimer = 8f;
    public int ShieldCharges = 3;
    public bool ShieldsUp = true;
    public ShieldText ShieldText;
    public float _shieldTimer = 0f;
    private ParticleSystem _shields;

    void Start()
    {
        _shields = GetComponentInChildren<ParticleSystem>();
    }


    void Update()
    {
        if (!ShieldsUp)
        {
            _shields.gameObject.SetActive(false);
            ShieldRecharge();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Projectile laser = other.gameObject.GetComponent<Projectile>();

        if (laser)
        {
            laser.Hit();
            ShieldCharges--;
            ShieldText.UpdateText(ShieldCharges);

            if (ShieldCharges <= 0)
            {
                ShieldsDown();
            }
            else
            {
                AudioSource.PlayClipAtPoint(ShieldsHitSFX, transform.position);
            }
        }
    }

    void ShieldsDown()
    {
        if (ShieldsUp)
        {
            ShieldsUp = false;
            AudioSource.PlayClipAtPoint(ShieldsDownSFX, transform.position);
            ShieldCharges = 0;
            ShieldsUp = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void ShieldRecharge()
    {
        _shieldTimer += Time.deltaTime;

        if (_shieldTimer >= ShieldRechargeTimer)
        {
            ShieldsUp = true;
            _shields.gameObject.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = true;
            _shieldTimer = 0f;
            ShieldCharges = 3;
            ShieldText.UpdateText(ShieldCharges);
            AudioSource.PlayClipAtPoint(ShieldsUpSFX, transform.position);
        }
    }
}
