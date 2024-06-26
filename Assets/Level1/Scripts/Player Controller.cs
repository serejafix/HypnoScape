using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 320f; // Скорость передвижения персонажа
	public float jumpForce = 200f; // Сила прыжка
	public float airResistance = 0.5f;
	public float fallGravityScale = 5000f;
	public float gravityScale = 5;
	private float leftLimit;
	private float rightLimit;

    Rigidbody2D rb;

	bool isGround;
	bool isLeft;
	bool isRight;

	public Button btnAttack; // Ссылка на кнопку на канвасе

	public LayerMask groundLayer;
	public Animator animator;

	Vector2 vecGrovity;

	// для посоха при атаке ->
	public Color targetColor = Color.red; // Целевой цвет, к которому будет меняться объект
	public float changeDuration = 1f; // Продолжительность изменения цвета

	private Color originalColor; // Исходный цвет объекта
	private Renderer renderer; // Ссылка на компонент Renderer объекта
	public GameObject Staff;
    // <!

    [SerializeField] private ParticleSystem pickupEffect; // Ссылка на систему частиц
    void Start()
	{
		renderer = Staff.GetComponent<Renderer>();
		originalColor = renderer.material.color;

		vecGrovity = new Vector2(0, -Physics2D.gravity.y);
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		rb.gravityScale = 50;
		rb.mass = 1;
		isLeft = false;
		isRight = false;
		jumpForce = 900;
		moveSpeed = 700;
		leftLimit = -1300;
		rightLimit = 21222;
        pickupEffect.Stop();
    }

	public void ChangeColor()
	{
		// Изменяем цвет объекта на целевой цвет за указанное время
		StartCoroutine(LerpColor(targetColor, changeDuration));
	}

	public void ResetColor()
	{
		// Возвращаем цвет объекта к исходному цвету
		renderer.material.color = originalColor;
	}

	private IEnumerator LerpColor(Color target, float duration)
	{
		float timeElapsed = 0f;
		Color startColor = renderer.material.color;

		while (timeElapsed < duration)
		{
			// Интерполируем между начальным и целевым цветом
			renderer.material.color = Color.Lerp(startColor, target, timeElapsed / duration);

			timeElapsed += Time.deltaTime;
			yield return null;
		}

		// Убеждаемся, что цвет установлен в конечный цвет точно
		renderer.material.color = target;

		ResetColor();
	}

	void Update()
	{
		if (isRight)
			rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
		else if (isLeft)
			rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
		else
			rb.velocity = new Vector2(0, rb.velocity.y);

		if (rb.velocity.y < 0)
		{
			rb.velocity -= vecGrovity * fallGravityScale * Time.deltaTime;
		}

		// Проверяем позицию по X
		if (transform.position.x < leftLimit)
		{
			transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
		}

        // Проверяем позицию по X
        if (transform.position.x > rightLimit)
        {
            transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
        }
        
        if (transform.position.y < -500f) // Проверяем позицию по Y
		{
			RestartLevel();
		}
    }

	public void leftButton()
	{
		// для зеркального отражения персонажа при ходьбе назад
		// Получаем текущий масштаб объекта
		Vector3 currentScale = transform.localScale;

		if (currentScale.x > 0)
		{
			currentScale.x *= -1;

			// Применяем новый масштаб к объекту
			transform.localScale = currentScale;
		}

		isLeft = true;
        animator.SetBool("Move", true);
	}

	public void rightButton()
	{
		// для зеркального отражения персонажа при ходьбе вперед 
		// Получаем текущий масштаб объекта
		Vector3 currentScale = transform.localScale;

		if (currentScale.x < 0)
		{
		  currentScale.x *= -1;

		  // Применяем новый масштаб к объекту
		  transform.localScale = currentScale;
		}

		isRight = true;

        animator.SetBool("Move", true);
    }

	public void upButton()
	{
		isLeft = false;
		isRight = false;

		animator.SetBool("Move", false);
	}

	public void jumpButton()
	{
		if (isGround)
		{
			animator.SetBool("Jump", true);
			rb.velocity = new Vector2(rb.velocity.x, 0f); // Сбрасываем вертикальную скорость перед прыжком
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
		
		Invoke("SetJumpFalse", 0.5f);
	}

	public void attackButton()
	{
		if (btnAttack.interactable)
		{
			ChangeColor();

			btnAttack.interactable = false;

			animator.SetBool("Attack", true);
		}

		Invoke("SetAttackFalse", 1.5f);
	}

	void SetJumpFalse()
	{
		animator.SetBool("Jump", false);
	}

	public void SetAttackFalse()
	{
		animator.SetBool("Attack", false);
		btnAttack.interactable = true;
	}

	private void OnCollisionEnter2D(Collision2D collision) // GroundCheck для прыжка
	{
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
            isGround = true;
	}

	private void OnCollisionExit2D(Collision2D collision) // GroundCheck для прыжка
	{
		if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
			isGround = false;
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		CoinManager.coins = 0;
		CrystalManager.coins = 0;
	}
}
