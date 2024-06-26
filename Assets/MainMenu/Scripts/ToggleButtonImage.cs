using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonImage : MonoBehaviour
{
	// Ссылка на компонент кнопки
	private Button button;

	// Массив изображений для кнопки
	public Sprite[] buttonImages;
	[SerializeField] AudioSource m_AudioSource;

	public AudioClip Background;
	// Индекс текущего изображения
	private int currentImageIndex = 0;

	private bool isMusicOn = true;

	void Start()
	{
        m_AudioSource.clip = Background;
		m_AudioSource.Play();

		// Получаем компонент кнопки
		button = GetComponent<Button>();

		// Назначаем метод OnButtonClick на событие нажатия кнопки
		button.onClick.AddListener(OnButtonClick);

		// Устанавливаем начальное изображение для кнопки
		UpdateButtonImage();
    }

	// Метод, вызываемый при нажатии на кнопку
	void OnButtonClick()
	{
		// Меняем состояние музыки
		isMusicOn = !isMusicOn;

		// Включаем или выключаем музыку в зависимости от состояния
		if (isMusicOn)
		{
			m_AudioSource.mute = false;
			Debug.Log("ВКЛ");
		}
		else
		{
			Debug.Log("ВЫКЛ");
			m_AudioSource.mute = true;
		}

		// Увеличиваем индекс текущего изображения на 1
		currentImageIndex++;

		// Если индекс превышает количество изображений, переходим к первому изображению
		if (currentImageIndex >= buttonImages.Length)
		{
			currentImageIndex = 0;
		}

		// Обновляем изображение кнопки
		UpdateButtonImage();
	}

	// Метод для обновления изображения кнопки
	void UpdateButtonImage()
	{
		// Получаем компонент изображения кнопки
		Image buttonImage = button.image;

		// Устанавливаем новое изображение для кнопки
		buttonImage.sprite = buttonImages[currentImageIndex];

	}
}