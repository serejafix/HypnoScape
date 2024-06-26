using System.Collections;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTrigger;
    private CrystalManager coinManager;
    [SerializeField]  private ParticleSystem characterEffect; // Ссылка на эффект персонажа
    public LevelManager levelManager;

    public AudioSource audioSource; // Ссылка на AudioSource

    private void Start()
    {
        coinManager = CrystalManager.instance;
        levelManager = LevelManager.instance;
    }

    // Метод для установки ссылки на эффект персонажа
    public void SetCharacterEffect(ParticleSystem effect)
    {
        characterEffect = effect;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTrigger)
        {
            hasTrigger = true;
            coinManager.ChangeCoins(value); // за золотую 5 серебных

            if (CoinManager.coins == 20 && CrystalManager.coins == 5)
                levelManager.CompleteLevel(1);

            if (audioSource != null)
            {
                audioSource.Play(); // Воспроизводим звук
            }

            if (characterEffect != null)
            {
                characterEffect.Play(); // Включаем эффект у персонажа
            }
            Destroy(gameObject);
        }
    }
}
