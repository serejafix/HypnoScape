using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    // Ссылки на дочерние объекты, которые вы хотите управлять
    public GameObject[] objectsDisableAfterLoad;
    public FadeOutText textFadeOutScript; // Ссылка на скрипт FadeOutText для текста
    public FadeOutImage imageFadeOutScript; // Ссылка на скрипт FadeOutImage для картинки

    private void Start()
    {
        // Вызываем метод EnableObjects через 5 секунд
        StartCoroutine(DisableObjectsAfterDelay(4f));
    }

    private IEnumerator DisableObjectsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Ждем заданное количество секунд

        // Отключаем объекты, которые нужно скрыть после загрузки
        foreach (GameObject obj in objectsDisableAfterLoad)
        {
            // Если это текст, запускаем плавное исчезновение
            if (obj.GetComponent<TMPro.TextMeshProUGUI>() != null)
            {
                textFadeOutScript.FadeOut();
            }
            // Если это картинка, запускаем плавное исчезновение
            else if (obj.GetComponent<UnityEngine.UI.Image>() != null)
            {
                imageFadeOutScript.FadeOut();
            }
        }

        SceneManager.LoadScene("MainMenu");
    }
}
