using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePath : MonoBehaviour
{   public Transform prePath;
    private float smooth = 0.3f;
    public Vector3 cameraRotateOffset ;
    private void FixedUpdate()
    {
        Vector3 positionOffset = prePath.position - cameraRotateOffset;
        positionOffset.z =  prePath.position.z;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, positionOffset, smooth);
        transform.position = smoothedPosition;
        transform.LookAt(prePath);
    }
}
