using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Snake snake = other.GetComponentInChildren<Snake>();
        Material newMAt = Colors.materials[Random.Range(0, Colors.materials.Count)];
        while (newMAt == snake.material)
        { newMAt = Colors.materials[Random.Range(0, Colors.materials.Count)]; }
        snake.SetColor(newMAt);
        snake.StartChangeColor();
    }
}
