using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] Transform win;
    private void OnCollisionEnter(Collision collision)
    {
        win.gameObject.SetActive(true);
    }
}
