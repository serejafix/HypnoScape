using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private const string LEVELKEY = "Level"; // Ключ для сохранения прогресса уровней

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняет объект между сценами
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Сохранение уровня как пройденного
    public void CompleteLevel(int levelNumber)
    {
        PlayerPrefs.SetInt(LEVELKEY + levelNumber, 1); // 1 означает, что уровень пройден
        PlayerPrefs.Save();

        if (levelNumber == 3)
            SceneManager.LoadScene("MainMenu");

        SceneManager.LoadScene("PreloaderLevel" + (levelNumber + 1).ToString());
    }

    // Проверка, пройден ли уровень
    public bool IsLevelCompleted(int levelNumber)
    {
        return PlayerPrefs.GetInt(LEVELKEY + levelNumber, 0) == 1; // 0 означает, что уровень не пройден
    }
}
