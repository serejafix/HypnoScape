using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Vector3 originalPosition;

    void Start()
    {
        // �������� ��������� Button, ������������� � ����� GameObject
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    // ����� ��� ��������� ������� ������� �� ������
    public void OnPointerDown(PointerEventData eventData)
    {
        // ����������� ������ ����, ������� �� ��������� �������
        rectTransform.anchoredPosition = originalPosition + new Vector3(0, -10, 0);
    }

    // ����� ��� ��������� ������� ���������� ������
    public void OnPointerUp(PointerEventData eventData)
    {
        // �������� ������� ������ �� ��������
        rectTransform.anchoredPosition = originalPosition;
    }
}
