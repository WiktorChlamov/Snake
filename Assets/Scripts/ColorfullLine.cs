using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorfullLine : Collide
{
    private BodyColor _bodyColor;

    public BodyColor BodyColor { get => _bodyColor; }

    private void Start()
    {
        _bodyColor = new BodyColor(GetComponent<MeshRenderer>());
        _bodyColor.SetRandomColor();
    }

}
