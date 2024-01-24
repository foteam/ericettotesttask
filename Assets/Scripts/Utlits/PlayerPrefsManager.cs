using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }
    
    public static string LoadString(string key, string defaultValue = "")
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    public static void IncInt(string key, int value)
    {
        int current = PlayerPrefs.GetInt(key);
        PlayerPrefs.SetInt(key, current+value);
        PlayerPrefs.Save();
    }

    public static void DecInt(string key, int value)
    {
        int current = PlayerPrefs.GetInt(key);
        PlayerPrefs.SetInt(key, current-value);
        PlayerPrefs.Save();
    }
    
    public static void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }
    
    public static int LoadInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }
    
}
