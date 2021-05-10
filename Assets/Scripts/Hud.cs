using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI crystals, eaten; 
    
    public void SetEaten(int count)
    {
        eaten.SetText("You ate " + count + " humans");
    }
    public void SetCrystal(int count)
    {
        crystals.SetText("You collected " + count + " crystal");
    }
    private void Start()
    {
        Input.multiTouchEnabled = false;
    }

}
