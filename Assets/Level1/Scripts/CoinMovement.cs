using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float floatHeight; // Высота подъема монетки
    public float floatSpeed; // Скорость движения монетки

    private Vector2 startPos; // Начальная позиция монетки

    void Start()
    {
        this.floatHeight = 15f;
        this.floatSpeed = 3f;

        startPos = transform.position; // Сохраняем начальную позицию монетки
    }

    void Update()
    {
        // Плавно поднимаем и опускаем монетку по оси Y
        transform.position = new Vector2(startPos.x, startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight);
    }
}
