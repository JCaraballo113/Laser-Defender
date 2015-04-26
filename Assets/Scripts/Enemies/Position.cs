using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour
{
    public LayerMask Layer;
    public float Padding = 1f;

    private float _xMin, _xMax, _yMin, _yMax;
    private FormationController _formationController;

    void Start()
    {
        _formationController = FindObjectOfType<FormationController>();

        if (PositionOverlaps())
        {
           MovePosition();
        }
    }

    bool PositionOverlaps()
    {
        transform.collider2D.enabled = false;
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, 0.1f, Layer);
        transform.collider2D.enabled = true;

        if (collisions.Length > 0)
        {
            Debug.Log(transform.name + " collided with: " + collisions[0].name);
            return true;
        }

        return false;

    }

    public void MovePosition()
    {
        _formationController.SetBounds();
        _xMin = _formationController._xMin;
        _xMax = _formationController._xMax;
        _yMin = _formationController._yMin;
        _yMax = _formationController._yMax;

        float randomPadding = Random.Range(0.5f, Padding);
        float randomX = Random.Range(_xMin + randomPadding, _xMax - randomPadding);
        float randomY = Random.Range(_yMin + randomPadding, _yMax - randomPadding);
        Vector3 randomPos = new Vector3(randomX, randomY, 0f);

        transform.position = randomPos;

        if (!PositionOverlaps())
        {
            return;
        }
        else
        {
            MovePosition();
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,1f);
    }
}
