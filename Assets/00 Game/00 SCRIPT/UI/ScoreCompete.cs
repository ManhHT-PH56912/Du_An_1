using UnityEngine;
using TMPro;

public class ScoreCompete : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [System.Obsolete]
    private void Update()
    {
        // Update UI with scores
        if (ScoreManager.Instance != null)
        {
            currentScoreText.text = $"Your Score: {ScoreManager.Instance.CurrentScore}";
            highScoreText.text = $"Your High Score: {ScoreManager.Instance.HighScore}";
        }
    }
}
