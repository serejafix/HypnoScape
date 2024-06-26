using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToogleOnOffGraphics : MonoBehaviour
{
	public Sprite imgOn;               // ������ ��� ����������� ���������
	public Sprite imgOff;              // ������ ��� ������������ ���������
	public Image buttonImage;          // ������ �� ��������� ����������� ������
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