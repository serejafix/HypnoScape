using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonsControlsSettings : MonoBehaviour
{
   [SerializeField] public Button btnSound;

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void High()
    {
        if (QualitySettings.GetQualityLevel() == 0)
            QualitySettings.SetQualityLevel(2);
        else
            QualitySettings.SetQualityLevel(0);
    }

    public void Sound()
    {
        SoundManager.ToggleSound();
    }
}

