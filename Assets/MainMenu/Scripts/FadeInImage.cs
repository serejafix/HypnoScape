using System.Collections;
using UnityEngine;

public class FadeInImage : MonoBehaviour
{
    public float fadeInDuration = 1.0f; // Продолжительность появления объекта
    private UnityEngine.UI.Image image; // Ссылка на компонент Image

    private void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>(); // Получаем компонент Image
    }

    public void Fade()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        // Устанавливаем начальное значение прозрачности
        Color color = image.color;
        color.a = 0f;
        image.color = color;
        Debug.Log("CALLED");
        // Плавно увеличиваем прозрачность объекта
        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration); // Интерполируем значение прозрачности
            color.a = alpha;
            image.color = color;
            yield return null;
        }
    }
}
