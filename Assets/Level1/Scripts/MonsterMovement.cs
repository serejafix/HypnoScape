using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float moveSpeed = 5f; // �������� ��������

    private Transform currentPoint;
    public bool isLevel3;

    void Start()
    {
        currentPoint = pointB.transform;
        Flip(false);
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
        localScale.x = Mathf.Abs(localScale.x) * (isLevel3 ? (isMovingForward ? -1 : 1) : (isMovingForward ? 1 : -1));
        transform.localScale = localScale;
    }
}
