using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private const string LEVELKEY = "Level"; // ���� ��� ���������� ��������� �������

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ������ ����� �������
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ���������� ������ ��� �����������
    public void CompleteLevel(int levelNumber)
    {
        PlayerPrefs.SetInt(LEVELKEY + levelNumber, 1); // 1 ��������, ��� ������� �������
        PlayerPrefs.Save();

        if (levelNumber == 3)
            SceneManager.LoadScene("MainMenu");

        SceneManager.LoadScene("PreloaderLevel" + (levelNumber + 1).ToString());
    }

    // ��������, ������� �� �������
    public bool IsLevelCompleted(int levelNumber)
    {
        return PlayerPrefs.GetInt(LEVELKEY + levelNumber, 0) == 1; // 0 ��������, ��� ������� �� �������
    }
}
