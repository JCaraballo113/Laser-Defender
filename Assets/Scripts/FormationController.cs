using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float width = 13.12f;
    public float height = 5.68f;
    public float moveSpeed = 15f;
    public float offset = 0f; // Offset to use so the formation does not surpass screen's width
    public float spawnDelay = 1f;

    private float _screenXMax, _screenXMin;
    private short _direction = 1;

    void Start()
    {

        _screenXMax = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f)).x;
        _screenXMin = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        offset = (width/2);

        SpawnUntilFull();
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

        if (AllMembersAreDead())
        {
            SpawnUntilFull();
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

    bool AllMembersAreDead()
    {
        foreach (Transform positionTransform in transform)
        {
            if (positionTransform.childCount > 0)
            {
                return false;
            }
        }

        return true;
    }

    void SpawnUntilFull()
    {
        Transform nextTransform = NextFreePosition();
        if (nextTransform)
        {
            GameObject enemy = Instantiate(EnemyPrefab, nextTransform.position, Quaternion.identity) as GameObject;
            if (enemy != null) enemy.transform.parent = nextTransform.transform;
        }

        if (FreePositionExists())
        {
            Invoke("SpawnUntilFull",spawnDelay);
        }
    }

    bool FreePositionExists()
    {
        foreach (Transform childTransform in transform)
        {
            if (childTransform.childCount > 0)
            {
                return true;
            }
        }

        return false;
    }

    Transform NextFreePosition()
    {
        foreach (Transform positionTransform in transform)
        {
            if (positionTransform.childCount <= 0)
            {
                return positionTransform;
            }
        }

        return null;
    }
}
