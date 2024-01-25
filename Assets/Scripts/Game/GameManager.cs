using System;
using System.Collections;
using System.Collections.Generic;
using ArcadeVP;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private GameObject _finishUI;
    [SerializeField] private GameObject _shopUI;

    private void OnEnable()
    {
        PlayerManager.onFinish += Finished;
    }

    private void OnDisable()
    {
        PlayerManager.onFinish -= Finished;
    }

    private void LateUpdate()
    {
        _coinsText.text = "Coins: " + PlayerPrefsManager.LoadInt("Coins").ToString();
        if (Input.GetKey(KeyCode.W)) _shopUI.SetActive(false);
        
    }
    private void Finished()
    {
        Debug.Log("Game Finished");
        _finishUI.SetActive(true);
    }
}
