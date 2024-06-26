using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public Image fogImage; // ������ �� ����������� ������
    public float transitionDuration = 1.5f; // ����������������� �������� � ��������

    private bool transitioning = false; // ���� ��� ������������ �������� ��������

    // ����� ��� ������� �������� ����� ��������
    public void StartTransition()
    {
        if (!transitioning)
        {
            StartCoroutine(Transition());
        }

        
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Level1");
    }

    // �������� ��� �������� ��������
    IEnumerator Transition()
    {
        transitioning = true;

        float timer = 0f;
        Color fogColor = fogImage.color;

        // ��������� ������
        while (timer < transitionDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / transitionDuration);
            fogColor.a = alpha;
            fogImage.color = fogColor;
            timer += Time.deltaTime;
            yield return null;
        }

        // ����� �� ������ �������� ������ �������� ������ ������ ��� �����
        this.LoadScene();
        // ������������ ������
        timer = 0f;
        while (timer < transitionDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / transitionDuration);
            fogColor.a = alpha;
            fogImage.color = fogColor;
            timer += Time.deltaTime;
            yield return null;
        }

        transitioning = false;
    }
}
