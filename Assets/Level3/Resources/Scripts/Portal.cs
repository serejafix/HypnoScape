using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
	private void GoToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			GoToMainMenu();
		}
	}
}
