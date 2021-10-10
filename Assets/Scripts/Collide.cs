using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    public virtual void Destroy(float time = 0f)
    {
        Destroy(gameObject, time);
    }
}
