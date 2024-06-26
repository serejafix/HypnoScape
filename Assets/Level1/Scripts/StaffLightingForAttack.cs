using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StaffLightingForAttack : MonoBehaviour
{
    public GameObject objectToFade; // Ссылка на объект, который будет изменять яркость
    public float fadeDuration = 0.5f; // Длительность затухания и восстановления
    public float maxAlpha = 1f; // Максимальная яркость (альфа-значение)
    public float minAlpha = 0f; // Минимальная яркость (альфа-значение)

    public void StartFade()
    {
        StartCoroutine(FadeObject());
    }

    IEnumerator FadeObject()
    {
        // Постепенно увеличиваем яркость до максимального значения
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            Color newColor = objectToFade.GetComponent<Renderer>().material.color;
            newColor.a = Mathf.Lerp(minAlpha, maxAlpha, normalizedTime);
            objectToFade.GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }

        // Постепенно уменьшаем яркость до минимального значения
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