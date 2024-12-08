using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int currentIndex;     // Chỉ số màn hình hiện tại
    private int totalScreens;     // Tổng số màn hình trong game

    private void Start()
    {
        // Lấy index của màn hình hiện tại và tổng số màn hình từ Build Settings
        currentIndex = SceneManager.GetActiveScene().buildIndex;
        totalScreens = SceneManager.sceneCountInBuildSettings;
    }

    public void MoveToNextLevel()
    {
        if (totalScreens > 0)
        {
            GameUtility.LoadScreen(ref currentIndex, totalScreens);
        }
        else
        {
            Debug.LogError("No screens available in Build Settings!");
        }
    }
}
