using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _crystalsField, _eatenField;
    [SerializeField] private Transform _gameOver;
    private int _eaten, _crystals;

    public void AddEaten()
    {
        _eaten++;
        _eatenField.SetText("You ate " + _eaten + " humans");
    }

    public void AddCrystal(out int count)
    {
        _crystals++;
        count = _crystals;
        _crystalsField.SetText(_crystals + " crystal");
    }

    public void ResetCrystals()
    {
        _crystals = 0;
        _crystalsField.SetText(_crystals + " crystal");
    }

    private void Start()
    {
        Input.multiTouchEnabled = false;
    }

    public void GameOver()
    {
        _gameOver.gameObject.SetActive(true);
    }

}
