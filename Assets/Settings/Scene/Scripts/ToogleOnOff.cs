using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToogleOnOff : MonoBehaviour
{
	public Sprite imgOn;               // Спрайт для включенного состояния
	public Sprite imgOff;              // Спрайт для выключенного состояния
	public Image buttonImage;          // Ссылка на компонент изображения кнопки

	public void Start()
	{
		if (SoundManager.soundEnabled)
		{
			buttonImage.sprite = imgOn;
		}
		else
		{
			buttonImage.sprite = imgOff;
		}
	}

	public void ToggleSound()
	{
		if (SoundManager.soundEnabled)
		{
			MusicManager.instance.TurnOnMusic();

			buttonImage.sprite = imgOn;
		}
		else
		{
			MusicManager.instance.TurnOffMusic();

			buttonImage.sprite = imgOff;
		}
	}
}