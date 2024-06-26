using UnityEngine;
using UnityEngine.UI;

public class ButtonPressEffect : MonoBehaviour
{
	// ������ �� ��������� ������
	private Button button;

	// ������ �� ��������� ��������
	private Animation animation;

	// ������ �� �������� �������
	public AnimationClip pressAnimation;

	void Start()
	{
		// �������� ��������� ������
		button = GetComponent<Button>();

		// �������� ��������� ��������
		animation = GetComponent<Animation>();

		// ���������, ���� �� �������� �������
		if (pressAnimation != null)
		{
			// ��������� �������� ������� � ��������� ��������
			animation.AddClip(pressAnimation, pressAnimation.name);

			// ��������� ����� OnButtonClick �� ������� ������� ������
			button.onClick.AddListener(OnButtonClick);
		}
		else
		{
			Debug.LogError("Press animation is not assigned.");
		}
	}

	// �����, ���������� ��� ������� �� ������
	void OnButtonClick()
	{
		// ���������, ��� �������� �������� � �� �������������
		if (animation != null && !animation.isPlaying)
		{
			// ������������� �������� �������
			animation.Play(pressAnimation.name);
		}
	}
}
