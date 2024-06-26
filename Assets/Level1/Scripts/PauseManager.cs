using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] public Object[] objectsToShow;

    public void ShowPauseMenu()
    {
        foreach (GameObject obj in objectsToShow)
        {
          obj.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(false);
        }

        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        ShowPauseMenu();
    }
}

