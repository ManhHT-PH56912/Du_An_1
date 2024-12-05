// using UnityEngine;

// public class ScoreData
// {
//     private int currentScore;
//     private int highScore;
//     private const string HIGH_SCORE_KEY = "HighScore";
//     private const string CURRENT_SCORE_KEY = "CurrentScore";

//     public int CurrentScore
//     {
//         get => currentScore;
//         set
//         {
//             currentScore = value;
//             PlayerPrefs.SetInt(CURRENT_SCORE_KEY, currentScore);
            
//             if (currentScore > highScore)
//             {
//                 highScore = currentScore;
//                 PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
//             }
//             PlayerPrefs.Save();
//         }
//     }

//     public int HighScore => highScore;

//     public ScoreData()
//     {
//         highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
//         currentScore = PlayerPrefs.GetInt(CURRENT_SCORE_KEY, 0);
//     }
// }
