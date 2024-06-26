using System.Collections;
using TMPro;
using UnityEngine;
public class FadeOutText : MonoBehaviour
{
    public float fadeOutDuration = 1.0f; // Продолжительность исчезновения текста
    private TMP_Text text; // Ссылка на компонент TextMeshProUGUI

    private void Start()
    {
        text = GetComponent<TMP_Text>(); // Получаем ссылку на компонент TextMeshProUGUI
    }

    // Метод для плавного исчезновения текста
    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        // Получаем начальный цвет текста
        Color color = text.color;

        // Плавно уменьшаем прозрачность текста до нуля
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration); // Интерполируем значение прозрачности
            color.a = alpha;
            text.color = color;
            yield return null;
        }

        // После завершения исчезновения отключаем объект с текстом
        gameObject.SetActive(false);
    }
}
