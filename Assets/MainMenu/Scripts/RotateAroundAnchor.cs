using UnityEngine;

public class RotateWithPivot : MonoBehaviour
{
    public Transform anchor; // Якорь, вокруг которого будет вращаться объект
    public float rotationSpeed = 50f; // Скорость вращения объекта
    public float maxAngle = 50f; // Максимальный угол отклонения

    private float currentAngle = 0f; // Текущий угол отклонения
    private bool rotateClockwise = true; // Направление вращения

    void Update()
    {
        // Проверяем, что якорь установлен
        if (anchor != null)
        {
            // Вычисляем направление от объекта к якорю
            Vector3 directionToAnchor = anchor.position - transform.position;

            // Находим угол между текущим направлением объекта и направлением к якорю
            float angleToAnchor = Vector3.SignedAngle(transform.right, directionToAnchor, Vector3.forward);

            // Если объект достиг максимального угла или минимального угла, меняем направление вращения
            if (Mathf.Abs(currentAngle) >= maxAngle)
            {
                rotateClockwise = !rotateClockwise;
            }

            // Вращаем объект в зависимости от направления
            float rotation = rotationSpeed * Time.deltaTime * (rotateClockwise ? 1 : -1);
            transform.RotateAround(anchor.position, Vector3.forward, rotation);

            // Обновляем текущий угол отклонения
            currentAngle += rotation;
        }
        else
        {
            Debug.LogError("Anchor point is not assigned!");
        }
    }
}
