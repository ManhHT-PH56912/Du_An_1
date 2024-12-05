// // ScoreManager.cs
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class ScoreManager : MonoBehaviour
// {
//     private static ScoreManager instance;

//     [System.Obsolete]
//     public static ScoreManager Instance
//     {
//         get
//         {
//             if (instance == null)
//             {
//                 instance = FindObjectOfType<ScoreManager>();
//                 if (instance == null)
//                 {
//                     GameObject go = new GameObject("ScoreManager");
//                     instance = go.AddComponent<ScoreManager>();
//                     DontDestroyOnLoad(go);
//                 }
//             }
//             return instance;
//         }
//     }

//     private ScoreData scoreData;
//     public event System.Action<int, int> OnScoreChanged;

//     private void Awake()
//     {
//         if (instance != null && instance != this)
//         {
//             Destroy(gameObject);
//             return;
//         }

//         instance = this;
//         DontDestroyOnLoad(gameObject);

//         scoreData = new ScoreData();

//         // Đăng ký sự kiện khi scene load
//         SceneManager.sceneLoaded += OnSceneLoaded;
//     }

//     private void OnDestroy()
//     {
//         SceneManager.sceneLoaded -= OnSceneLoaded;
//     }

//     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//     {
//         // Reset điểm khi load map mới
//         if (scene.name.StartsWith("Map"))
//         {
//             ResetScore();
//             Debug.Log($"Score reset on loading map: {scene.name}");
//         }
//     }

//     public int CurrentScore => scoreData.CurrentScore;
//     public int HighScore => scoreData.HighScore;

//     public void AddScore(int points)
//     {
//         scoreData.CurrentScore += points;
//         OnScoreChanged?.Invoke(scoreData.CurrentScore, scoreData.HighScore);
//     }

//     public void ResetScore()
//     {
//         scoreData.CurrentScore = 0;
//         OnScoreChanged?.Invoke(scoreData.CurrentScore, scoreData.HighScore);
//     }

//     public void HandleEndGame()
//     {
//         // Update high score if current score is higher
//         if (scoreData.CurrentScore > scoreData.HighScore)
//         {
//             // ScoreData will automatically update the high score in PlayerPrefs
//             Debug.Log($"New High Score achieved! Previous: {scoreData.HighScore}, New: {scoreData.CurrentScore}");
//         }

//         // Save current score to PlayerPrefs
//         PlayerPrefs.SetInt("LastGameScore", scoreData.CurrentScore);
//         PlayerPrefs.Save();

//         Debug.Log($"Game ended with score: {scoreData.CurrentScore}");
//     }
// }
