using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float width = 13.12f;
    public float height = 5.68f;
    public float moveSpeed = 15f;
    public float offset = 0f; // Offset to use so the formation does not surpass screen's width

    private float _screenXMax, _screenXMin;
    private short _direction = 1;
    private short _enemyCount = 0;

    void Start()
    {

        _screenXMax = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f)).x;
        _screenXMin = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        offset = (width/2);

        foreach (Transform childTransform in transform)
        {
            GameObject enemy = Instantiate(EnemyPrefab, childTransform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = childTransform.transform;
            _enemyCount++;
        }
    }

    void Update()
    {
        // I move the formation
        Move();

        // I calculate the position of the formation
        float xPosFormation = this.transform.position.x;

        // If the position of the formation is greater than or less than the screen's width I make it move the other way
        if (xPosFormation + offset > _screenXMax)
        {
            _direction = -1;
        }
        else if (xPosFormation - offset < _screenXMin)
        {
            _direction = 1;
        }
    }

    void OnDrawGizmos()
    {
        float xMin, xMax, yMin, yMax;
        xMin = transform.position.x - 0.5f * width;
        xMax = transform.position.x + 0.5f * width;
        yMin = transform.position.y - 0.5f * height;
        yMax = transform.position.y + 0.5f * height;

        Gizmos.DrawLine(new Vector3(xMin,yMin,0f),new Vector3(xMin,yMax,0f));
        Gizmos.DrawLine(new Vector3(xMin, yMax, 0f), new Vector3(xMax, yMax, 0f));
        Gizmos.DrawLine(new Vector3(xMax, yMax, 0f), new Vector3(xMax, yMin, 0f));
        Gizmos.DrawLine(new Vector3(xMax, yMin, 0f), new Vector3(xMin, yMin, 0f));
    }

    void Move()
    {
        Vector3 moveVector = new Vector3(moveSpeed * _direction * Time.deltaTime,0f,0f);
        this.transform.position += moveVector;
    }

    public void EnemyDestroyed()
    {
        _enemyCount--;

        if (_enemyCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
