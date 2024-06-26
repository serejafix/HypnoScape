using UnityEngine;
using TMPro;

public class FireFly1Manager : MonoBehaviour
{
    public static FireFly1Manager instance;

    public static int coins;
    [SerializeField] private TMP_Text coinsDisplay;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    private void OnGUI()
    {
        coinsDisplay.text = coins.ToString();
    }

    public void ChangeCoins(int amount)
    {
        coins += amount;
    }
}
