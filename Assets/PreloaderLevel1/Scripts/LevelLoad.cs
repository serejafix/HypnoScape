using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    public int levelNumber;
    private float delay = 3f; // �������� ����� ��������� ������

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Preloader Start!");
        StartCoroutine(LoadLevelAfterDelay(levelNumber, delay));
    }

    private IEnumerator LoadLevelAfterDelay(int levelNumber, float delay)
    {
        Debug.Log($"Waiting for {delay} seconds before loading level {levelNumber}.");
        yield return new WaitForSeconds(delay); // ���� �������� ���������� ������
        Debug.Log("Delay finished. Loading level...");
        LoadLevel(levelNumber); // ��������� �������
    }

    private void LoadLevel(int levelNumber)
    {
        Debug.Log($"Loading level: Level{levelNumber}");
        SceneManager.LoadScene($"Level{levelNumber}", LoadSceneMode.Single);
    }
}
