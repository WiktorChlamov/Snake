using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Snake snake = collision.gameObject.GetComponentInChildren<Snake>();
            if (!snake.fever)
                snake.GameOver();
            else Destroy(gameObject);
        }
    }
}
