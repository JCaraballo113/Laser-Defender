using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 3;

    private FormationController _formationController;

    void Start()
    {
        _formationController = gameObject.GetComponentInParent<FormationController>();
    }

    public void Damage(int points)
    {
        Health -= points;

        if (Health <= 0)
        {
            _formationController.EnemyDestroyed();
            Destroy(gameObject);
        }
    }
}
