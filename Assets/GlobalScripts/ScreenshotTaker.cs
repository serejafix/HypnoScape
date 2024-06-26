using UnityEngine;
using System.IO;

public class ScreenshotTaker : MonoBehaviour
{
    public KeyCode screenshotKey = KeyCode.P; // ������� ��� ���������
    public int screenshotWidth = 1920;        // ������ ���������
    public int screenshotHeight = 1080;       // ������ ���������
    public string savePath = "E:/Screenshots"; // ���� ��� ���������� ����������

    private void Start()
    {
        // ������� ����� ��� ����������, ���� �� ���
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            Debug.Log("Created directory: " + savePath);
        }
    }

    private void Update()
    {
        // �������������� �������� ��� Input.GetKey
        if (Input.GetKey(screenshotKey))
        {
            TakeScreenshot();
        }
    }

    private void TakeScreenshot()
    {
        // ���������� ��� �����
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string filePath = Path.Combine(savePath, "screenshot_" + timestamp + ".png");

        // ������ ��������
        ScreenCapture.CaptureScreenshot(filePath, 1);
        Debug.Log("Screenshot saved to: " + filePath);
    }
}
