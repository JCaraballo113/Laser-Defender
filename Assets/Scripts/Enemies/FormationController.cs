using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class FormationController : MonoBehaviour
{
    public static GameObject Formation = null;
    public GameObject[] EnemyPrefabs;
    public GameObject Position;
    public float Padding = 1f;
    public float MoveSpeed = 15f;
    public float Offset = 0f; // Offset to use so the formation does not surpass screen's bounds
    public float SpawnDelay = 1f;
    public float _xMin, _xMax, _yMin, _yMax;
    public int _maxEnemies = 5;

    private float _width = 0f;
    private float _height = 0f;
    private int _ceiling = 0;
    private int _positionCount = 0;
    private float _screenXMax, _screenXMin; // Screen Bounds in the X plane
    private short _direction = 1;

    void Start()
    {
        if (Formation == null)
        {
            Formation = this.gameObject;
            _screenXMax = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f)).x;
            _screenXMin = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
            _width = Random.Range(5f, _screenXMax);
            _height = 5f;

            _ceiling = Convert.ToInt32(Mathf.Ceil(_width));

            _maxEnemies = Random.Range(5, _ceiling);


            SetBounds();


            Offset = (_width/2);

            while (_positionCount < _maxEnemies)
            {
                CreatePosition();
                _positionCount++;
            }

            SpawnUntilFull();
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    void Update()
    {

        // I move the formation
        Move();

        // I calculate the position of the formation
        float xPosFormation = this.transform.position.x;

        // If the position of the formation is greater than or less than the screen's _width I make it move the other way
        if (xPosFormation + Offset > _screenXMax)
        {
            _direction = -1;
        }
        else if (xPosFormation - Offset < _screenXMin)
        {
            _direction = 1;
        }

        if (_maxEnemies <= 0)
        {
            Destroy(gameObject);
            Formation = null;
        }
    }

    void OnDrawGizmos()
    {
        float xMin, xMax, yMin, yMax;
        xMin = transform.position.x - 0.5f * _width;
        xMax = transform.position.x + 0.5f * _width;
        yMin = transform.position.y - 0.5f * _height;
        yMax = transform.position.y + 0.5f * _height;

        Gizmos.DrawLine(new Vector3(xMin,yMin,0f),new Vector3(xMin,yMax,0f));
        Gizmos.DrawLine(new Vector3(xMin, yMax, 0f), new Vector3(xMax, yMax, 0f));
        Gizmos.DrawLine(new Vector3(xMax, yMax, 0f), new Vector3(xMax, yMin, 0f));
        Gizmos.DrawLine(new Vector3(xMax, yMin, 0f), new Vector3(xMin, yMin, 0f));
    }

    void Move()
    {
        Vector3 moveVector = new Vector3(MoveSpeed * _direction * Time.deltaTime,0f,0f);
        this.transform.position += moveVector;
    }

    public void SetBounds()
    {
        _xMin = transform.position.x - 0.5f * _width;
        _xMax = transform.position.x + 0.5f * _width;
        _yMin = transform.position.y - 0.5f * _height;
        _yMax = transform.position.y + 0.5f * _height;
    }

    void CreatePosition()
    {
        SetBounds();

        float randomPadding = Random.Range(0.5f, Padding);
        float randomX = 0f;
        float randomY = 0f;

        randomX = Random.Range(_xMin + randomPadding, _xMax - randomPadding);
        randomY = Random.Range(_yMin + randomPadding, _yMax - randomPadding);

        Vector3 randomPos = new Vector3(randomX, randomY, 0f);
        GameObject position = Instantiate(Position, randomPos, Quaternion.identity) as GameObject;
        position.transform.parent = transform;
        position.name = "Position " + _positionCount;
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

    void SpawnUntilFull()
    {
        Transform nextTransform = NextFreePosition();
        if (nextTransform)
        {
            int randomEnemy = Random.Range(0, EnemyPrefabs.Length);
            GameObject enemy = Instantiate(EnemyPrefabs[randomEnemy], nextTransform.position, Quaternion.identity) as GameObject;
            if (enemy != null) enemy.transform.parent = nextTransform.transform;
        }

        if (FreePositionExists())
        {
            Invoke("SpawnUntilFull",SpawnDelay);
        }
    }

    public void DestroyPosition(Transform position)
    {
        _maxEnemies--;
        Destroy(position.gameObject);
    }

    
}
