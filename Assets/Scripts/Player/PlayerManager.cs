using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject coinSoundEmpty;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            collision.gameObject.tag = "Untagged";
            Instantiate(coinSoundEmpty, collision.gameObject.transform.position, Quaternion.identity);
            PlayerPrefsManager.IncInt("Coins", 200);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Instantiate(coinSoundEmpty, other.gameObject.transform.position, Quaternion.identity);
            PlayerPrefsManager.IncInt("Coins", 5);
            Debug.Log("Coins; "+PlayerPrefs.GetInt("Coins"));
            Destroy(other.gameObject);
        }
    }
}
