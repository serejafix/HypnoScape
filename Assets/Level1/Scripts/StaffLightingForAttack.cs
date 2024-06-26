using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StaffLightingForAttack : MonoBehaviour
{
    public GameObject objectToFade; // ������ �� ������, ������� ����� �������� �������
    public float fadeDuration = 0.5f; // ������������ ��������� � ��������������
    public float maxAlpha = 1f; // ������������ ������� (�����-��������)
    public float minAlpha = 0f; // ����������� ������� (�����-��������)

    public void StartFade()
    {
        StartCoroutine(FadeObject());
    }

    IEnumerator FadeObject()
    {
        // ���������� ����������� ������� �� ������������� ��������
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            Color newColor = objectToFade.GetComponent<Renderer>().material.color;
            newColor.a = Mathf.Lerp(minAlpha, maxAlpha, normalizedTime);
            objectToFade.GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }

        // ���������� ��������� ������� �� ������������ ��������
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            Color newColor = objectToFade.GetComponent<Renderer>().material.color;
            newColor.a = Mathf.Lerp(maxAlpha, minAlpha, normalizedTime);
            objectToFade.GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }
    }
}