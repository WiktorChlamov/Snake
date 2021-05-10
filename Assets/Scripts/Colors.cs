using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    public Material one;
    public Material two;
    public Material three;
    public Material four;
    public Material five;
    public Material six;
    public static List<Material> materials;
    private void Awake()
    {
        materials = new List<Material>() { one, two,three,four,five,six};
    }
}
