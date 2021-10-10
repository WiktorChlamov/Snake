using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : Collide
{
    [SerializeField] private Transform win;
    public void WinGame()
    { 
        win.gameObject.SetActive(true);
    }
}
