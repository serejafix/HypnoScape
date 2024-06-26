using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTrigger;
    private CoinManager coinManager;
    [SerializeField]  private ParticleSystem characterEffect; // Ссылка на эффект персонажа
    public LevelManager levelManager;

    public AudioSource audioSource; // Ссылка на AudioSource

    private void Start()
    {
        coinManager = CoinManager.instance;
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
            
            if (characterEffect != null)
            {
                characterEffect.Play(); // Включаем эффект у персонажа
            }

            if (audioSource != null)
            {
                audioSource.Play(); // Воспроизводим звук
            }

            if (CoinManager.coins == 20 && CrystalManager.coins == 5)
                levelManager.CompleteLevel(1);

            Destroy(gameObject);
        }
    }
}
