using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject coinSoundEmpty;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Instantiate(coinSoundEmpty, other.gameObject.transform.position, Quaternion.identity);
            PlayerPrefsManager.IncInt("Coins", 1);
            Debug.Log("Coins; "+PlayerPrefs.GetInt("Coins"));
            Destroy(other.gameObject);
        }
    }
}
