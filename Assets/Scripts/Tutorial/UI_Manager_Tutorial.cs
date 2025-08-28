using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager_Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] UI;
    [SerializeField] private GameObject playerPoints;

    int selectedUI = 0;

    private void Update()
    {
        Debug.Log(selectedUI);
    }
    public void EnablePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
        UI[selectedUI].GetComponent<Button>().enabled = false;
        selectedUI++;
        slidePlayerPoint();
    } 

    private void slidePlayerPoint()
    {
        playerPoints.transform.position = Vector2.Lerp(transform.position, new Vector2(UI[selectedUI].transform.position.x, playerPoints.transform.position.y), 1f);
        UI[selectedUI].GetComponent<Button>().enabled = true;
    }

    public void ChangeScene(string go)
    {
        SceneManager.LoadScene(go, LoadSceneMode.Additive);

        UI[selectedUI].GetComponent<Button>().enabled = false;

        if (go != "Tutorial_PVP")
        {
            selectedUI++;
            slidePlayerPoint();
        }
    }
    public void UnloadScene(string go)
    {

        SceneManager.UnloadSceneAsync(go);
        if (go ==  "Tutorial_PVP")
        {
            SceneManager.UnloadSceneAsync("Tutorial");
            SceneManager.LoadScene("Menu");
        }
    }
}
