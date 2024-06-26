using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Статическая переменная для хранения состояния звука
    public static bool soundEnabled = true;

    // Метод для включения/выключения звука
    public static void ToggleSound()
    {
        soundEnabled = !soundEnabled;
        // Дополнительные действия при включении/выключении звука, если нужно
    }
}