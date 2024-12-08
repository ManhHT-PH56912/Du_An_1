using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    public static void GotoMainMenu()
    {
        SceneManager.LoadScene(Consts.Scenes.MAIN_MENU);
    }

    public static void PlayGame()
    {
        SceneManager.LoadScene(Consts.Scenes.MAP1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        // Nếu đang ở trong Editor, dừng play mode
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
#else
        // Nếu là build game, thoát trò chơi
        Application.Quit();
#endif
    }
}

