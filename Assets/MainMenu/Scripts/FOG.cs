using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public Image fogImage; // Ссылка на изображение тумана
    public float transitionDuration = 1.5f; // Продолжительность перехода в секундах

    private bool transitioning = false; // Флаг для отслеживания процесса перехода

    // Метод для запуска перехода между уровнями
    public void StartTransition()
    {
        if (!transitioning)
        {
            StartCoroutine(Transition());
        }

        
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Level1");
    }

    // Корутина для анимации перехода
    IEnumerator Transition()
    {
        transitioning = true;

        float timer = 0f;
        Color fogColor = fogImage.color;

        // Появление тумана
        while (timer < transitionDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / transitionDuration);
            fogColor.a = alpha;
            fogImage.color = fogColor;
            timer += Time.deltaTime;
            yield return null;
        }

        // Здесь вы можете добавить логику загрузки нового уровня или сцены
        this.LoadScene();
        // Исчезновение тумана
        timer = 0f;
        while (timer < transitionDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / transitionDuration);
            fogColor.a = alpha;
            fogImage.color = fogColor;
            timer += Time.deltaTime;
            yield return null;
        }

        transitioning = false;
    }
}
