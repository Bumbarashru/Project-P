using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonManager : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasReleasedThisFrame)
        {
            ExitTheGame();
        }
    }
    public void EnablePanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void ExitTheGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
