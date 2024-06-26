using UnityEngine;
using UnityEngine.UI;

public class ColorArrayAnimation : MonoBehaviour
{
    public Color[] colors; // Массив цветов для анимации
    public float duration = 2f; // Продолжительность анимации между каждым цветом

    private Image image; // Ссылка на компонент Image
    private int currentIndex = 0; // Текущий индекс цвета в массиве
    private float startTime; // Время начала анимации

    void Start()
    {
        // Получаем компонент Image
        image = GetComponent<Image>();

        // Запоминаем время начала анимации
        startTime = Time.time;

        // Устанавливаем начальный цвет Image
        image.color = colors[currentIndex];
    }

    void Update()
    {
        // Вычисляем прошедшее время с начала анимации
        float t = (Time.time - startTime) / duration;

        // Если прошло достаточно времени, переходим к следующему цвету
        if (t >= 1f)
        {
            // Увеличиваем индекс цвета
            currentIndex = (currentIndex + 1) % colors.Length;

            // Устанавливаем новый цвет Image
            image.color = colors[currentIndex];

            // Сбрасываем время начала анимации
            startTime = Time.time;
        }
    }
}