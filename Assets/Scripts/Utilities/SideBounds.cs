using UnityEngine;
using System.Collections;

public class SideBounds : MonoBehaviour {

    public float ScreenXMin;
    public float pos = 1f;

    void Start()
    {
        ScreenXMin = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        transform.position = new Vector3((ScreenXMin * pos - (0.5f * pos)), 0f, 0f);
    }
}
