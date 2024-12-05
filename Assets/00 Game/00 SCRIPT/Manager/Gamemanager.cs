// // Cách sử dụng trong GameManager
// using DesignPattern.Singleton;
// using UnityEngine;
// public class GameManager : Singleton<GameManager>
// {
//     [System.Obsolete]
//     public void OnLogginAccount()
//     {
//         ScoreManager.Instance.ResetScore();
//     }

//     [System.Obsolete]
//     public void OnPlayerScored(int points)
//     {
//         ScoreManager.Instance.AddScore(points);
//     }

//     [System.Obsolete]
//     public void OnGameOver()
//     {
//         Debug.Log($"Final Score: {ScoreManager.Instance.CurrentScore}");
//         Debug.Log($"High Score: {ScoreManager.Instance.HighScore}");
//     }
// }