using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void EnablePanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void SceneLoad(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void ExitTheGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasReleasedThisFrame)
        {
            ExitTheGame();
        }
    }
}
