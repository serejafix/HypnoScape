using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float floatHeight; // ������ ������� �������
    public float floatSpeed; // �������� �������� �������

    private Vector2 startPos; // ��������� ������� �������

    void Start()
    {
        this.floatHeight = 15f;
        this.floatSpeed = 3f;

        startPos = transform.position; // ��������� ��������� ������� �������
    }

    void Update()
    {
        // ������ ��������� � �������� ������� �� ��� Y
        transform.position = new Vector2(startPos.x, startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight);
    }
}
