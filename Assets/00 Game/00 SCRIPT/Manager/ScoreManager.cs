using DesignPattern.Singleton;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int CurrentScore { get; private set; }
    public int HighScore { get; private set; }
    public int TotalScore { get; private set; }

    protected override void Awake()
    {
       base.Awake();
    }

    private void Start()
    {
        LoadScores();
    }

    // Increment score
    public void AddScore(int amount)
    {
        CurrentScore += amount;

        // Update HighScore if necessary
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            SaveHighScore();
        }

        // Update TotalScore
        TotalScore += amount;
        SaveTotalScore();
    }

    // Deduct score for purchases
    public bool SpendScore(int amount)
    {
        if (TotalScore >= amount)
        {
            TotalScore -= amount;
            SaveTotalScore();
            return true;
        }
        return false;
    }

    // Reset the current score after a game session
    public void ResetCurrentScore()
    {
        CurrentScore = 0;
    }

    // Save HighScore
    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }

    // Save TotalScore
    private void SaveTotalScore()
    {
        PlayerPrefs.SetInt("TotalScore", TotalScore);
        PlayerPrefs.Save();
    }

    // Load HighScore and TotalScore
    private void LoadScores()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        TotalScore = PlayerPrefs.GetInt("TotalScore", 0);
    }
}
