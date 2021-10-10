using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 cameraRotateOffset;

    private void LateUpdate() => transform.position = new Vector3(cameraRotateOffset.x, cameraRotateOffset.y, _player.position.z + cameraRotateOffset.z);
}
