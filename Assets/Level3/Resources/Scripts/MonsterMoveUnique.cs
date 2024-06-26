using UnityEngine;

public class MonsterMoveUnique : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float moveSpeed = 5f; // �������� ��������

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
        // ���������� ������ � ������� ������� �����
        transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, moveSpeed * Time.deltaTime);

        // ��������, �������� �� �� ������� ������� �����
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
