using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutImage : MonoBehaviour
{
    public float fadeOutDuration = 1.0f; // ����������������� ������������ �����������
    private Image image; // ������ �� ��������� Image

    private void Start()
    {
        image = GetComponent<Image>(); // �������� ������ �� ��������� Image
    }

    // ����� ��� �������� ������������ �����������
    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        // �������� ��������� ���� �����������
        Color color = image.color;

        // ������ ��������� ������������ ����������� �� ����
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration); // ������������� �������� ������������
            color.a = alpha;
            image.color = color;
            yield return null;
        }

        // ����� ���������� ������������ ��������� ������ � ������������
        gameObject.SetActive(false);
    }
}
