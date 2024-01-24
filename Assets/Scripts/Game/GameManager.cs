using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;

    private void LateUpdate()
    {
        _coinsText.text = "Coins: " + PlayerPrefsManager.LoadInt("Coins").ToString();
    }
}
