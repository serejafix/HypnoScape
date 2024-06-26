using UnityEngine;
using TMPro;

public class CrystalManager : MonoBehaviour
{
    public static CrystalManager instance;

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