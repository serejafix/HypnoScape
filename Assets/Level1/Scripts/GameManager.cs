using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public static Object[] objectsToShow;
    [SerializeField] public int levelnumber;

    public void Start()
    {
        MusicManager.instance.PlayMusic($"Level{levelnumber}");

        if (levelnumber == 1)
        {
            CoinManager.coins = 0;
            CrystalManager.coins = 0;
        }
        else if (levelnumber == 2)
        {
            FireFly1Manager.coins = 0;
            FireFly2Manager.coins = 0;
        }
    }   

    public static void ShowGameOverMenu()
    {
        foreach (GameObject obj in objectsToShow)
        {
          obj.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void Repeat()
    {
        SceneManager.LoadScene("Level1");

        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public static void GameOver()
    {
        ShowGameOverMenu();
    }
}

