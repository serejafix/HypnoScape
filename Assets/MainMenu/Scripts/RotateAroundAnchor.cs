using UnityEngine;

public class RotateWithPivot : MonoBehaviour
{
    public Transform anchor; // �����, ������ �������� ����� ��������� ������
    public float rotationSpeed = 50f; // �������� �������� �������
    public float maxAngle = 50f; // ������������ ���� ����������

    private float currentAngle = 0f; // ������� ���� ����������
    private bool rotateClockwise = true; // ����������� ��������

    void Update()
    {
        // ���������, ��� ����� ����������
        if (anchor != null)
        {
            // ��������� ����������� �� ������� � �����
            Vector3 directionToAnchor = anchor.position - transform.position;

            // ������� ���� ����� ������� ������������ ������� � ������������ � �����
            float angleToAnchor = Vector3.SignedAngle(transform.right, directionToAnchor, Vector3.forward);

            // ���� ������ ������ ������������� ���� ��� ������������ ����, ������ ����������� ��������
            if (Mathf.Abs(currentAngle) >= maxAngle)
            {
                rotateClockwise = !rotateClockwise;
            }

            // ������� ������ � ����������� �� �����������
            float rotation = rotationSpeed * Time.deltaTime * (rotateClockwise ? 1 : -1);
            transform.RotateAround(anchor.position, Vector3.forward, rotation);

            // ��������� ������� ���� ����������
            currentAngle += rotation;
        }
        else
        {
            Debug.LogError("Anchor point is not assigned!");
        }
    }
}
