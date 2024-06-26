using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsControl : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clickSound;

    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        // Assign the click sound to the audio source
        if (clickSound != null)
        {
            audioSource.clip = clickSound;
        }

        //if (SoundManager.soundEnabled)
        // MusicManager.PlayMusicMainMenu();
    }
    public void ChoiceLevel()
    {
        ClickSound();
        SceneManager.LoadScene("ChoiceScene");
    }

    public void Settings()
    {
        ClickSound();
        SceneManager.LoadScene("Settings");
    }

    public void About()
    {
        ClickSound();
        SceneManager.LoadScene("About");
    }

    public void Exit()
    {
        ClickSound();
        Application.Quit();
    }
    
    private void ClickSound()
    {
        if (audioSource != null && clickSound != null && SoundManager.soundEnabled)
        {
            Debug.Log(1);
            audioSource.Play();
        }
    }
}
