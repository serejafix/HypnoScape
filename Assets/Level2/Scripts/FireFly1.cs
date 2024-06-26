using UnityEngine;

public class FireFly1 : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTrigger;
    private FireFly1Manager coinManager;
    [SerializeField]  private ParticleSystem characterEffect; // Ссылка на эффект персонажа
    public LevelManager levelManager;

    public AudioSource audioSource; // Ссылка на AudioSource

    private void Start()
    {
        coinManager = FireFly1Manager.instance;
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

            if (FireFly1Manager.coins == 5 && FireFly2Manager.coins == 5)
                levelManager.CompleteLevel(2);

            Destroy(gameObject);
        }
    }
}
