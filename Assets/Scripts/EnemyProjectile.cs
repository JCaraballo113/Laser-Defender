using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour 
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
