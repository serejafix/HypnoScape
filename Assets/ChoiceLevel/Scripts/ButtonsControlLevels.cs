using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsControlLevels : MonoBehaviour
{
	public void Level1()
	{
		SceneManager.LoadScene("PreloaderLevel1");
	}

	public void Level2()
	{
		SceneManager.LoadScene("PreloaderLevel2");
	}

	public void Level3()
	{
		SceneManager.LoadScene("PreloaderLevel3");
	}

	public void BackToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
