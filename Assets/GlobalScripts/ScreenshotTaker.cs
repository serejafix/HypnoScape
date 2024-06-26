using UnityEngine;
using System.IO;

public class ScreenshotTaker : MonoBehaviour
{
    public KeyCode screenshotKey = KeyCode.P; // Клавиша для скриншота
    public int screenshotWidth = 1920;        // Ширина скриншота
    public int screenshotHeight = 1080;       // Высота скриншота
    public string savePath = "E:/Screenshots"; // Путь для сохранения скриншотов

    private void Start()
    {
        // Создаем папку для скриншотов, если ее нет
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            Debug.Log("Created directory: " + savePath);
        }
    }

    private void Update()
    {
        // Дополнительная проверка для Input.GetKey
        if (Input.GetKey(screenshotKey))
        {
            TakeScreenshot();
        }
    }

    private void TakeScreenshot()
    {
        // Генерируем имя файла
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string filePath = Path.Combine(savePath, "screenshot_" + timestamp + ".png");

        // Делаем скриншот
        ScreenCapture.CaptureScreenshot(filePath, 1);
        Debug.Log("Screenshot saved to: " + filePath);
    }
}
