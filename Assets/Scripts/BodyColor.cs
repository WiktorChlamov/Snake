using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColor
{
    public Material Material { get; set; }

    [SerializeField] private MeshRenderer _selfMeshRenderer;

    public BodyColor(MeshRenderer selfMeshRenderer)
    {
        _selfMeshRenderer = selfMeshRenderer;
    }

    public void SetRandomColor()
    {
        Material material = Colors.Materials[Random.Range(0, Colors.Materials.Count)];
        SetColor(material);
    }

        public void SetColor(Material mat)
    {
        Material = mat;
        _selfMeshRenderer.material = Material;
    }
}
