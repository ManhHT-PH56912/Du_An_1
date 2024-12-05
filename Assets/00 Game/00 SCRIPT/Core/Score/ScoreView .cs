// // ScoreView.cs
// using UnityEngine;
// using TMPro;

// public class ScoreView : MonoBehaviour
// {
//     [SerializeField] private TextMeshProUGUI currentScoreText;
//     [SerializeField] private TextMeshProUGUI highScoreText;

//     [Header("Format Settings")]
//     [SerializeField] private string scoreFormat = "00000000"; // Format mặc định "000000"
//     [SerializeField] private string scorePrefix = ""; // Tiền tố (nếu cần)
//     [SerializeField] private string scoreSuffix = ""; // Hậu tố (nếu cần)

//     [System.Obsolete]
//     private void Awake()
//     {
//         // Try to find components if they're not assigned
//         if (currentScoreText == null)
//             currentScoreText = transform.Find("CurrentScoreText")?.GetComponent<TextMeshProUGUI>();
//         if (highScoreText == null)
//             highScoreText = transform.Find("HighScoreText")?.GetComponent<TextMeshProUGUI>();

//         if (currentScoreText == null || highScoreText == null)
//         {
//             Debug.LogError("TextMeshPro components not assigned to ScoreView! Please assign them in the inspector or name your TextMeshPro objects 'CurrentScoreText' and 'HighScoreText'");
//             return;
//         }
        
//         // Cập nhật UI ngay khi khởi tạo
//         UpdateScoreUI();
//     }

//     [System.Obsolete]
//     private void OnEnable()
//     {
//         if (ScoreManager.Instance == null)
//         {
//             Debug.LogError("ScoreManager instance is null!");
//             return;
//         }

//         // Đăng ký nhận sự kiện thay đổi điểm
//         // ScoreManager.Instance.OnScoreChanged += OnScoreChanged;
        
//         // Cập nhật UI với điểm hiện tại
//         UpdateScoreUI();
//     }

//     [System.Obsolete]
//     private void OnDisable()
//     {
//         if (ScoreManager.Instance != null)
//         {
//             ScoreManager.Instance.OnScoreChanged -= OnScoreChanged;
//         }
//     }

//     [System.Obsolete]
//     private void OnScoreChanged(int currentScore, int highScore)
//     {
//         UpdateScoreUI();
//     }

//     [System.Obsolete]
//     private void UpdateScoreUI()
//     {
//         if (currentScoreText != null)
//         {
//             string formattedCurrentScore = ScoreManager.Instance.CurrentScore.ToString(scoreFormat);
//             currentScoreText.text = $"{scorePrefix}{formattedCurrentScore}{scoreSuffix}";
//         }

//         if (highScoreText != null)
//         {
//             string formattedHighScore = ScoreManager.Instance.HighScore.ToString(scoreFormat);
//             highScoreText.text = $"{scorePrefix}{formattedHighScore}{scoreSuffix}";
//         }
//     }
// }
