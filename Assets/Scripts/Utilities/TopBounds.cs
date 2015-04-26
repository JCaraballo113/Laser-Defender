using UnityEngine;
using System.Collections;

public class TopBounds : MonoBehaviour
{
    public float ScreenYMin;
    public float pos = 1f;
    public bool DestroyShips = false;

    void Start()
    {
        ScreenYMin = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f,0f)).y;
        transform.position = new Vector3(0f,(ScreenYMin * pos - (0.5f * pos)),0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
        }
        else if (other.tag == "Enemy" && DestroyShips)
        {
            Destroy(other.gameObject);
        }
    }
}
