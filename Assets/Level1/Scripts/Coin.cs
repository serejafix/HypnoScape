using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTrigger;
    private CoinManager coinManager;
    [SerializeField]  private ParticleSystem characterEffect; // ������ �� ������ ���������
    public LevelManager levelManager;

    public AudioSource audioSource; // ������ �� AudioSource

    private void Start()
    {
        coinManager = CoinManager.instance;
        levelManager = LevelManager.instance;
    }

    // ����� ��� ��������� ������ �� ������ ���������
    public void SetCharacterEffect(ParticleSystem effect)
    {
        characterEffect = effect;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTrigger)
        {
            hasTrigger = true;
            coinManager.ChangeCoins(value); // �� ������� 5 ��������
            
            if (characterEffect != null)
            {
                characterEffect.Play(); // �������� ������ � ���������
            }

            if (audioSource != null)
            {
                audioSource.Play(); // ������������� ����
            }

            if (CoinManager.coins == 20 && CrystalManager.coins == 5)
                levelManager.CompleteLevel(1);

            Destroy(gameObject);
        }
    }
}
