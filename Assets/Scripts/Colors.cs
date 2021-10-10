using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    [SerializeField] private Material _one;
    [SerializeField] private Material _two;
    [SerializeField] private Material _three;
    [SerializeField] private Material _four;
    [SerializeField] private Material _five;
    [SerializeField] private Material _six;
    private static List<Material> _materials;

    public static List<Material> Materials { get => _materials;}

    private void Awake()
    {
        _materials = new List<Material>() { _one, _two,_three,_four,_five,_six};
    }
}
