using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 15.0f;
    public float Padding = 1f;
    public bool CanControl = false;

    private float xMax, xMin;

    void Start()
    {
        Camera cam = Camera.main;

        float distance = this.transform.position.z - cam.transform.position.z;

        xMin = cam.ViewportToWorldPoint(new Vector3(0f, 0f, distance)).x + Padding;
        xMax = cam.ViewportToWorldPoint(new Vector3(1f, 1f, distance)).x - Padding;
    }

    void Update()
    {
        if (CanControl)
        {
            Destroy(gameObject.GetComponent<Animator>(),0.2f);
        }

        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
                Move(horizontal);
            
        }
    }

    void Move(float h)
    {
        float moveX = Mathf.Clamp(this.transform.position.x + (MoveSpeed * h) * Time.deltaTime,xMin,xMax);

        Vector3 movementVector = new Vector3(moveX, this.transform.position.y, this.transform.position.z);
        transform.position = movementVector;
    }
}
