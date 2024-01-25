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

        public void SetColor(string colorName)
        {
            PlayerPrefsManager.SaveString("Color", colorName);
            changeColor?.Invoke(colorName); // Call change color function at PlayerManager
        }
    }
}