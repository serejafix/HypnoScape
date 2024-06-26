using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutImage : MonoBehaviour
{
    public float fadeOutDuration = 1.0f; // Продолжительность исчезновения изображения
    private Image image; // Ссылка на компонент Image

    private void Start()
    {
        image = GetComponent<Image>(); // Получаем ссылку на компонент Image
    }

    // Метод для плавного исчезновения изображения
    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        // Получаем начальный цвет изображения
        Color color = image.color;

        // Плавно уменьшаем прозрачность изображения до нуля
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration); // Интерполируем значение прозрачности
            color.a = alpha;
            image.color = color;
            yield return null;
        }

        // После завершения исчезновения отключаем объект с изображением
        gameObject.SetActive(false);
    }
}
