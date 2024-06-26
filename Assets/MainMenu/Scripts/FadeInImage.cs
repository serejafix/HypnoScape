using System.Collections;
using UnityEngine;

public class FadeInImage : MonoBehaviour
{
    public float fadeInDuration = 1.0f; // ����������������� ��������� �������
    private UnityEngine.UI.Image image; // ������ �� ��������� Image

    private void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>(); // �������� ��������� Image
    }

    public void Fade()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        // ������������� ��������� �������� ������������
        Color color = image.color;
        color.a = 0f;
        image.color = color;
        Debug.Log("CALLED");
        // ������ ����������� ������������ �������
        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration); // ������������� �������� ������������
            color.a = alpha;
            image.color = color;
            yield return null;
        }
    }
}
