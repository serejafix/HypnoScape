using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // ����������� ���������� ��� �������� ��������� �����
    public static bool soundEnabled = true;

    // ����� ��� ���������/���������� �����
    public static void ToggleSound()
    {
        soundEnabled = !soundEnabled;
        // �������������� �������� ��� ���������/���������� �����, ���� �����
    }
}