using UnityEngine;

public class Test : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ������������ ���������
    public float jumpForce = 10f; // ���� ������

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �������� �����
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("RIGHT");
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        // �������� ������
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("LEFT");
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        // ��������� ��������������� ��������
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // ������
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // ���������, ��������� �� �������� �� �����
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // ���������, ������� �� �������� �����
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
