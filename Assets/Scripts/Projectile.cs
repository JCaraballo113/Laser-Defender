using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private float _Damage = 100f;

    public float GetDamage()
    {
        return _Damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
