using UnityEngine;

public class Test : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость передвижения персонажа
    public float jumpForce = 10f; // Сила прыжка

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Движение влево
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("RIGHT");
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        // Движение вправо
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("LEFT");
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        // Остановка горизонтального движения
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Проверяем, находится ли персонаж на земле
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Проверяем, покинул ли персонаж землю
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
