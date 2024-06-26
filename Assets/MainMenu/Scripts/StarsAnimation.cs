using UnityEngine;
using UnityEngine.UI;

public class ColorArrayAnimation : MonoBehaviour
{
    public Color[] colors; // ������ ������ ��� ��������
    public float duration = 2f; // ����������������� �������� ����� ������ ������

    private Image image; // ������ �� ��������� Image
    private int currentIndex = 0; // ������� ������ ����� � �������
    private float startTime; // ����� ������ ��������

    void Start()
    {
        // �������� ��������� Image
        image = GetComponent<Image>();

        // ���������� ����� ������ ��������
        startTime = Time.time;

        // ������������� ��������� ���� Image
        image.color = colors[currentIndex];
    }

    void Update()
    {
        // ��������� ��������� ����� � ������ ��������
        float t = (Time.time - startTime) / duration;

        // ���� ������ ���������� �������, ��������� � ���������� �����
        if (t >= 1f)
        {
            // ����������� ������ �����
            currentIndex = (currentIndex + 1) % colors.Length;

            // ������������� ����� ���� Image
            image.color = colors[currentIndex];

            // ���������� ����� ������ ��������
            startTime = Time.time;
        }
    }
}