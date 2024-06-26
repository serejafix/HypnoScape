using System.Collections;
using UnityEngine;

public class TrapMovement : MonoBehaviour
{
    public float targetHeight = 5.0f;  // ������, �� ������� ����� ����������� ���
    public float moveDuration = 1.0f;  // ����� �� ������ � �����
    public float waitTime = 3.0f;      // ����� �������� ����� �����������

    private Vector3 initialPosition;   // ��������� ������� ����

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(MoveSpike());
    }

    IEnumerator MoveSpike()
    {
        while (true)
        {
            // ������ ����
            yield return StartCoroutine(MoveToPosition(initialPosition + Vector3.up * targetHeight, moveDuration));

            // �������� �� ������� �������
            yield return new WaitForSeconds(waitTime);

            // ����� ����
            yield return StartCoroutine(MoveToPosition(initialPosition, moveDuration));

            // �������� �� ������ �������
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator MoveToPosition(Vector3 target, float duration)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
}
