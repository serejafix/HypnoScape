using UnityEngine;

public class ParallaxEffect2D : MonoBehaviour
{
    public Transform player; // Ссылка на трансформ персонажа
    public float[] parallaxFactors; // Массив факторов параллакса для каждого слоя
    public float viewZone = 10f; // Зона видимости, за пределами которой слои перемещаются

    private Vector3 previousPlayerPosition; // Предыдущее положение персонажа
    private float layerLengthX; // Длина слоя по оси X
    private float layerLengthY; // Длина слоя по оси Y

    private void Start()
    {
        // Инициализация предыдущего положения персонажа
        previousPlayerPosition = player.position;

        // Предполагаем, что все слои одинакового размера и берем размер первого слоя
        if (transform.childCount > 0)
        {
            layerLengthX = transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;
            layerLengthY = transform.GetChild(0).GetComponent<Renderer>().bounds.size.y;
        }
    }

    private void Update()
    {
        // Вычисляем смещение игрока с момента последнего кадра
        Vector3 deltaMovement = player.position - previousPlayerPosition;

        // Перебираем все дочерние объекты и применяем параллакс-эффект
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            float parallaxFactor = parallaxFactors[i];

            // Смещаем слой в зависимости от параллакс-фактора
            Vector3 newPosition = child.position + new Vector3(deltaMovement.x * parallaxFactor, deltaMovement.y * parallaxFactor, 0);
            child.position = newPosition;

            // Проверка и зацикливание слоя по оси X
            if (player.position.x - child.position.x > layerLengthX)
            {
                child.position = new Vector3(child.position.x + layerLengthX * 2, child.position.y, child.position.z);
            }
            else if (child.position.x - player.position.x > layerLengthX)
            {
                child.position = new Vector3(child.position.x - layerLengthX * 2, child.position.y, child.position.z);
            }

            // Проверка и зацикливание слоя по оси Y
            if (player.position.y - child.position.y > layerLengthY)
            {
                child.position = new Vector3(child.position.x, child.position.y + layerLengthY * 2, child.position.z);
            }
            else if (child.position.y - player.position.y > layerLengthY)
            {
                child.position = new Vector3(child.position.x, child.position.y - layerLengthY * 2, child.position.z);
            }
        }

        // Обновляем предыдущее положение игрока
        previousPlayerPosition = player.position;
    }
}
