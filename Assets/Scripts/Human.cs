using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public Material material;
    [SerializeField]
    private MeshRenderer selfMeshRenderer;
    public void SetColor(Material mat)
    {
        material = mat;
        selfMeshRenderer.material = material;
    }
}
