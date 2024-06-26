using System.Collections;
using TMPro;
using UnityEngine;
public class FadeOutText : MonoBehaviour
{
    public float fadeOutDuration = 1.0f; // ����������������� ������������ ������
    private TMP_Text text; // ������ �� ��������� TextMeshProUGUI

    private void Start()
    {
        text = GetComponent<TMP_Text>(); // �������� ������ �� ��������� TextMeshProUGUI
    }

    // ����� ��� �������� ������������ ������
    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        // �������� ��������� ���� ������
        Color color = text.color;

        // ������ ��������� ������������ ������ �� ����
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration); // ������������� �������� ������������
            color.a = alpha;
            text.color = color;
            yield return null;
        }

        // ����� ���������� ������������ ��������� ������ � �������
        gameObject.SetActive(false);
    }
}
