using System.Collections;
using UnityEngine;

public class TrapMovement : MonoBehaviour
{
    public float targetHeight = 5.0f;  // Высота, на которую будет подниматься шип
    public float moveDuration = 1.0f;  // Время на подъем и спуск
    public float waitTime = 3.0f;      // Время ожидания перед повторением

    private Vector3 initialPosition;   // Начальная позиция шипа

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(MoveSpike());
    }

    IEnumerator MoveSpike()
    {
        while (true)
        {
            // Подъем шипа
            yield return StartCoroutine(MoveToPosition(initialPosition + Vector3.up * targetHeight, moveDuration));

            // Ожидание на верхней позиции
            yield return new WaitForSeconds(waitTime);

            // Спуск шипа
            yield return StartCoroutine(MoveToPosition(initialPosition, moveDuration));

            // Ожидание на нижней позиции
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
