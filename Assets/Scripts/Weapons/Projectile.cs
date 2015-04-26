using UnityEngine;
using System.Collections;

public  class Projectile : MonoBehaviour
{
    private float _damage = 0f;

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    public float GetDamage()
    {
        return _damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
