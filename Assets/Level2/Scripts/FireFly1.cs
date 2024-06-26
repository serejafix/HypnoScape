using UnityEngine;

public class FireFly1 : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTrigger;
    private FireFly1Manager coinManager;
    [SerializeField]  private ParticleSystem characterEffect; // ������ �� ������ ���������
    public LevelManager levelManager;

    public AudioSource audioSource; // ������ �� AudioSource

    private void Start()
    {
        coinManager = FireFly1Manager.instance;
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

            if (FireFly1Manager.coins == 5 && FireFly2Manager.coins == 5)
                levelManager.CompleteLevel(2);

            Destroy(gameObject);
        }
    }
}
