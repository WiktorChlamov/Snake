using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    public Vector3 cameraRotateOffset;
    private void LateUpdate() => transform.position = new Vector3(cameraRotateOffset.x, cameraRotateOffset.y, player.position.z + cameraRotateOffset.z);
}
