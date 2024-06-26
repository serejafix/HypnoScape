using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToogleOnOffGraphics : MonoBehaviour
{
	public Sprite imgOn;               // Спрайт для включенного состояния
	public Sprite imgOff;              // Спрайт для выключенного состояния
	public Image buttonImage;          // Ссылка на компонент изображения кнопки
	private bool lOn; 
	public void Start()
	{
        lOn = true;
        buttonImage.sprite = imgOn;
    }

	public void Toggle()
	{
		lOn = !lOn;
		Debug.Log(lOn);
		if (lOn)
			buttonImage.sprite = imgOn;
		else
			buttonImage.sprite = imgOff;
    }
}