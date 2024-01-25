using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public delegate void ChangeColor(string colorName);

        public static event ChangeColor changeColor;
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void NextLevel()
        {
            int maxLevels = 3;
            int currentLevel = Int32.Parse(SceneManager.GetActiveScene().name.Split("level_0")[1]);
            string nextSceneName = "level_0" + (currentLevel + 1);
            if (currentLevel + 1 > maxLevels) SceneManager.LoadScene("level_01");
            if (currentLevel + 1 <= maxLevels) SceneManager.LoadScene(nextSceneName);
        }

        public void SetColor(string colorName)
        {
            PlayerPrefsManager.SaveString("Color", colorName);
            changeColor?.Invoke(colorName); // Call change color function at PlayerManager
        }
    }
}