using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumansStartColor : MonoBehaviour
{
    [SerializeField] private Human[] _humans;

    private void Start()
    {
        Material material = Colors.Materials[Random.Range(0, Colors.Materials.Count)];
        foreach(Human hm in _humans)
        {
            hm.BodyColor = default;
            hm.BodyColor.SetColor(material);
        }
    }
}
