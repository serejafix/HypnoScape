using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    // ������ �� �������� �������, ������� �� ������ ���������
    public GameObject[] objectsDisableAfterLoad;
    public FadeOutText textFadeOutScript; // ������ �� ������ FadeOutText ��� ������
    public FadeOutImage imageFadeOutScript; // ������ �� ������ FadeOutImage ��� ��������

    private void Start()
    {
        // �������� ����� EnableObjects ����� 5 ������
        StartCoroutine(DisableObjectsAfterDelay(4f));
    }

    private IEnumerator DisableObjectsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ���� �������� ���������� ������

        // ��������� �������, ������� ����� ������ ����� ��������
        foreach (GameObject obj in objectsDisableAfterLoad)
        {
            // ���� ��� �����, ��������� ������� ������������
            if (obj.GetComponent<TMPro.TextMeshProUGUI>() != null)
            {
                textFadeOutScript.FadeOut();
            }
            // ���� ��� ��������, ��������� ������� ������������
            else if (obj.GetComponent<UnityEngine.UI.Image>() != null)
            {
                imageFadeOutScript.FadeOut();
            }
        }

        SceneManager.LoadScene("MainMenu");
    }
}
