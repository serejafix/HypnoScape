using UnityEngine;

public class MonsterMoveUnique : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float moveSpeed = 5f; // Скорость движения

    private Transform currentPoint;
    private Animator animator;
    void Start()
    {
        currentPoint = pointB.transform;
        animator = GetComponent<Animator>();
        Flip(false);
        animator.SetBool("unique", true);
    }

    void Update()
    {
        // Перемещаем объект к текущей целевой точке
        transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, moveSpeed * Time.deltaTime);

        // Проверка, достигли ли мы текущей целевой точки
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.1f)
        {
            if (currentPoint == pointB.transform)
            {
                Flip(true);
                currentPoint = pointA.transform;
            }
            else
            {
                Flip(false);
                currentPoint = pointB.transform;
            }
        }
    }

    private void Flip(bool isMovingForward)
    {
        Vector3 localScale = transform.localScale;
        localScale.x = Mathf.Abs(localScale.x) * (isMovingForward ? -1 : 1);
        transform.localScale = localScale;
    }
}
