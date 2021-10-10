using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePath : MonoBehaviour
{   
    public Transform prePath;
    private float _smooth = 0.3f;
    public Vector3 followDistantion ;

    private void FixedUpdate()
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, prePath.position, _smooth);
        transform.position = smoothedPosition;
        transform.LookAt(prePath);
    }
}
