using System.Collections;
using UnityEngine;

public class FireFly2 : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTrigger;
    private FireFly2Manager coinManager;
    [SerializeField]  private ParticleSystem characterEffect; // ������ �� ������ ���������
    public LevelManager levelManager;

    public AudioSource audioSource; // ������ �� AudioSource

    private void Start()
    {
        coinManager = FireFly2Manager.instance;
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

            if (FireFly1Manager.coins == 5 && FireFly2Manager.coins == 5)
                levelManager.CompleteLevel(1);

            if (audioSource != null)
            {
                audioSource.Play(); // ������������� ����
            }

            if (characterEffect != null)
            {
                characterEffect.Play(); // �������� ������ � ���������
            }
            Destroy(gameObject);
        }
    }
}
