using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private GameObject _finishUI;

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
    }

    private void Finished()
    {
        Debug.Log("Game Finished");
        _finishUI.SetActive(true);
    }
}
