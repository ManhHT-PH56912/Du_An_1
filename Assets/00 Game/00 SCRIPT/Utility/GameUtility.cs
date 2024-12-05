using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameUtility
{
    // Phương thức tiện ích để di chuyển GameObject đến vị trí mới
    public static void MoveTo(GameObject obj, Vector3 newPosition)
    {
        obj.transform.position = newPosition;
    }

    // Phương thức tiện ích để thay đổi kích thước GameObject
    public static void Resize(GameObject obj, Vector3 newSize)
    {
        obj.transform.localScale = newSize;
    }

    // Phương thức tiện ích để bật/tắt GameObject
    public static void SetActive(GameObject obj, bool isActive)
    {
        obj.SetActive(isActive);
    }

    // Phương thức chụp ảnh màn hình hiện tại và lưu vào file
    public static void CaptureCurrentScreen(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        ScreenCapture.CaptureScreenshot(path);
        Debug.Log($"Screenshot saved to: {path}");
    }

    // Phương thức tải màn hình dựa trên index và tăng index
    public static void LoadScreen(ref int currentIndex, int totalScreens)
    {
        // Tăng index (vòng lặp lại từ đầu nếu vượt quá tổng số màn hình)
        currentIndex = (currentIndex + 1) % totalScreens;

        // Tải màn hình theo index
        SceneManager.LoadScene(currentIndex);
        Debug.Log($"Loaded Screen Index: {currentIndex}");
    }
}
