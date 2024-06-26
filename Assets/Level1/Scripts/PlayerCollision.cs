using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
	[SerializeField] public Object[] objectsToShow;
	[SerializeField] public int levelNumber;

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Enemy")
		{
			Debug.Log("Portal");
			HearthManager.health--;

			if (HearthManager.health <= 0)
			{
				foreach (GameObject obj in objectsToShow)
				{
					obj.SetActive(true);
				}

				Time.timeScale = 0f;
			}
			else
			{
				StartCoroutine(GetHurt());
			}
		}
		else if (collision.transform.tag == "Portal")
		{
			Debug.Log("Portal");
			this.BackToMainMenu();
		}
	}
	IEnumerator GetHurt()
	{
		//Physics2D.IgnoreLayerCollision(3, 4);
		GetComponent<Animator>().SetLayerWeight(1, 1);
		yield return new WaitForSeconds(3);
		GetComponent<Animator>().SetLayerWeight(1, 0);
		//Physics2D.IgnoreLayerCollision(6, 8, false);
	}

	public void Repeat()
	{
		SceneManager.LoadScene($"Level{levelNumber}");
		Time.timeScale = 1f;

		CoinManager.coins = 0;
		CrystalManager.coins = 0;
	}

	public void BackToMainMenu()
	{
        SceneManager.LoadScene("MainMenu");
	}

	public void Exit()
	{
		Application.Quit();
	}

}
