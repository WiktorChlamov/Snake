using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMaterial : MonoBehaviour
{
    public Material material;
    [SerializeField] Human[] humans;
    private void Awake()
    {
        material= Colors.materials[Random.Range(0, Colors.materials.Count)];
        foreach(Human hm in humans)
        {
            hm.SetColor(material);
        }
    }
    private void Start()
    {
        
    }
}
