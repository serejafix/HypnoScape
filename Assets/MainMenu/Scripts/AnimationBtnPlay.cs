using UnityEngine;
using UnityEngine.UI;

public class ButtonPressEffect : MonoBehaviour
{
	// Ссылка на компонент кнопки
	private Button button;

	// Ссылка на компонент анимации
	private Animation animation;

	// Ссылка на анимацию нажатия
	public AnimationClip pressAnimation;

	void Start()
	{
		// Получаем компонент кнопки
		button = GetComponent<Button>();

		// Получаем компонент анимации
		animation = GetComponent<Animation>();

		// Проверяем, есть ли анимация нажатия
		if (pressAnimation != null)
		{
			// Добавляем анимацию нажатия в компонент анимации
			animation.AddClip(pressAnimation, pressAnimation.name);

			// Назначаем метод OnButtonClick на событие нажатия кнопки
			button.onClick.AddListener(OnButtonClick);
		}
		else
		{
			Debug.LogError("Press animation is not assigned.");
		}
	}

	// Метод, вызываемый при нажатии на кнопку
	void OnButtonClick()
	{
		// Проверяем, что анимация доступна и не проигрывается
		if (animation != null && !animation.isPlaying)
		{
			// Воспроизводим анимацию нажатия
			animation.Play(pressAnimation.name);
		}
	}
}
