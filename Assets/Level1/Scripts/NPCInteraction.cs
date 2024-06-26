using UnityEngine;
using System.Collections;

public class NPCInteraction : MonoBehaviour
{
    // —сылка на спрайт, который будет показыватьс€ и скрыватьс€
    public GameObject interactionWindow;
    private SpriteRenderer spriteRenderer;
    public float fadeDuration = 0.5f;

    void Start()
    {
        if (interactionWindow != null)
        {
            spriteRenderer = interactionWindow.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                spriteRenderer = interactionWindow.AddComponent<SpriteRenderer>();
            }
            SetSpriteAlpha(0f); // »значально скрываем окно
            interactionWindow.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Interaction window is not assigned in the inspector.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (interactionWindow != null)
            {
                interactionWindow.SetActive(true);
                StopAllCoroutines();
                StartCoroutine(FadeIn());
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (interactionWindow != null)
            {
                StopAllCoroutines();
                StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            SetSpriteAlpha(Mathf.Clamp01(elapsedTime / fadeDuration));
            yield return null;
        }
        SetSpriteAlpha(1f);
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            SetSpriteAlpha(Mathf.Clamp01(1f - (elapsedTime / fadeDuration)));
            yield return null;
        }
        SetSpriteAlpha(0f);
        interactionWindow.SetActive(false);
    }

    void SetSpriteAlpha(float alpha)
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }
}
