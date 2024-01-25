using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject coinSoundEmpty;
    [SerializeField] private MeshRenderer _carMesh;
    [SerializeField] private Material[] _colors;

    public static Action onFinish; // Action at the finish

    private void Awake()
    {
        // Load color via PlayerPrefs
        string color = PlayerPrefsManager.LoadString("Color");
        if (color != null)
        {
            SetColor(color); // Setting saved color
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish")) // Finish dialog, open finish UI
        {
            collision.gameObject.tag = "Untagged";
            Instantiate(coinSoundEmpty, collision.gameObject.transform.position, Quaternion.identity);
            PlayerPrefsManager.IncInt("Coins", 200);
            onFinish?.Invoke(); // Call finish function at Gamemanager
        }
    }
    private void OnEnable()
    {
        UIManager.changeColor += SetColor; // Change color action via Buttons, buttons have string parameter for naming of color
    }

    private void OnDisable()
    {
        UIManager.changeColor -= SetColor; // Change color action via Buttons, buttons have string parameter for naming of color
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin")) // Coin collector
        {
            Instantiate(coinSoundEmpty, other.gameObject.transform.position, Quaternion.identity);
            PlayerPrefsManager.IncInt("Coins", 5);
            Destroy(other.gameObject);
        }
    }
    public void SetColor(string colorName) // Changing color via material
    {
        switch (colorName)
        {
            case "yellow":
                _carMesh.material = _colors[0];
                PlayerPrefsManager.DecInt("Coins", 200);
                break;
            case "green":
                _carMesh.material = _colors[1];
                PlayerPrefsManager.DecInt("Coins", 200);
                break;
            case "red":
                _carMesh.material = _colors[2];
                PlayerPrefsManager.DecInt("Coins", 200);
                break;
        }
    }
}
