using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour
{
    private float _randomVertical;
    private float _randomHorizontal;


    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,1f);
    }
}
