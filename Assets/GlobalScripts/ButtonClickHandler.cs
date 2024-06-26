using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Vector3 originalPosition;

    void Start()
    {
        // Получить компонент Button, прикрепленный к этому GameObject
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    // Метод для обработки события нажатия на кнопку
    public void OnPointerDown(PointerEventData eventData)
    {
        // Переместить кнопку вниз, изменив ее локальную позицию
        rectTransform.anchoredPosition = originalPosition + new Vector3(0, -10, 0);
    }

    // Метод для обработки события отпускания кнопки
    public void OnPointerUp(PointerEventData eventData)
    {
        // Сбросить позицию кнопки на исходную
        rectTransform.anchoredPosition = originalPosition;
    }
}
