using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonImage : MonoBehaviour
{
	// ������ �� ��������� ������
	private Button button;

	// ������ ����������� ��� ������
	public Sprite[] buttonImages;
	[SerializeField] AudioSource m_AudioSource;

	public AudioClip Background;
	// ������ �������� �����������
	private int currentImageIndex = 0;

	private bool isMusicOn = true;

	void Start()
	{
        m_AudioSource.clip = Background;
		m_AudioSource.Play();

		// �������� ��������� ������
		button = GetComponent<Button>();

		// ��������� ����� OnButtonClick �� ������� ������� ������
		button.onClick.AddListener(OnButtonClick);

		// ������������� ��������� ����������� ��� ������
		UpdateButtonImage();
    }

	// �����, ���������� ��� ������� �� ������
	void OnButtonClick()
	{
		// ������ ��������� ������
		isMusicOn = !isMusicOn;

		// �������� ��� ��������� ������ � ����������� �� ���������
		if (isMusicOn)
		{
			m_AudioSource.mute = false;
			Debug.Log("���");
		}
		else
		{
			Debug.Log("����");
			m_AudioSource.mute = true;
		}

		// ����������� ������ �������� ����������� �� 1
		currentImageIndex++;

		// ���� ������ ��������� ���������� �����������, ��������� � ������� �����������
		if (currentImageIndex >= buttonImages.Length)
		{
			currentImageIndex = 0;
		}

		// ��������� ����������� ������
		UpdateButtonImage();
	}

	// ����� ��� ���������� ����������� ������
	void UpdateButtonImage()
	{
		// �������� ��������� ����������� ������
		Image buttonImage = button.image;

		// ������������� ����� ����������� ��� ������
		buttonImage.sprite = buttonImages[currentImageIndex];

	}
}