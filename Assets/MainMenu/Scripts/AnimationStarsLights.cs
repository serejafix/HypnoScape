//using UnityEngine;
//using UnityEngine.UI;

//public class AnimationStarsLights : MonoBehaviour
//{
//    Image image;
//    public Color[] colors;
//    public float duration = 1f;

//    private int currentIndex = 0;
//    private float elapsedTime = 0f;

//    void Start()
//    {
//        image = GetComponent<Image>();
//        // ������������� ��������� ���� �����������
//        image.color = colors[currentIndex];
//    }

//    void Update()
//    {
//        // ����������� ��������� �����
//        elapsedTime += Time.deltaTime;

//        // ��������� ������� �������� ��������
//        float t = Mathf.Clamp01(elapsedTime / duration);

//        // ������������� ����� ������� � ��������� �������
//        Color currentColor = Color.Lerp(colors[currentIndex], colors[(currentIndex + 1) % colors.Length], t);
//        image.color = currentColor;

//        // ���� ��������� ����� ���������, ��������� � ���������� �����
//        if (elapsedTime >= duration)
//        {
//            currentIndex = (currentIndex + 1) % colors.Length;
//            elapsedTime = 0f; // �������� elapsedTime ����� ���������� duration
//        }
//    }
//}

using UnityEngine;
using UnityEngine.UI;

public class AnimationStarsLights : MonoBehaviour
{
    public Color startColor = Color.green;
    public Color endColor = Color.black;
    [Range(0, 10)]
    public float speed = 1;

    private Image imgComp;

    void Awake()
    {
        imgComp = GetComponent<Image>();
    }

    void Update()
    {
        // ���������� �������������� ������� ��� �������� �������� ����� �������
        float t = Mathf.Sin(Time.time * speed * Mathf.PI * 2) * 0.5f + 0.5f;
        imgComp.color = Color.Lerp(startColor, endColor, t);
    }
}