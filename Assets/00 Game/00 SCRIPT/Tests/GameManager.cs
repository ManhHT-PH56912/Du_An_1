using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [System.Obsolete]
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    [Header("Score UI References")]
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [Header("Score Format Settings")]
    [SerializeField] private string scoreFormat = "000000"; // Format mặc định
    [SerializeField] private string scorePrefix = ""; // Tiền tố
    [SerializeField] private string scoreSuffix = ""; // Hậu tố

    private ScoreData scoreData;

    public int CurrentScore => scoreData.CurrentScore;
    public int HighScore => scoreData.HighScore;

    public event System.Action<int, int> OnScoreChanged;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        scoreData = new ScoreData();

        // Đăng ký sự kiện khi load scene
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.StartsWith("Map"))
        {
            ResetScore();
            Debug.Log($"Score reset on loading map: {scene.name}");
        }

        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        scoreData.CurrentScore += points;
        if (scoreData.CurrentScore > scoreData.HighScore)
        {
            scoreData.HighScore = scoreData.CurrentScore;
        }
        OnScoreChanged?.Invoke(scoreData.CurrentScore, scoreData.HighScore);
        UpdateScoreUI();
    }

    public void ResetScore()
    {
        scoreData.CurrentScore = 0;
        OnScoreChanged?.Invoke(scoreData.CurrentScore, scoreData.HighScore);
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (currentScoreText != null)
        {
            string formattedCurrentScore = scoreData.CurrentScore.ToString(scoreFormat);
            currentScoreText.text = $"{scorePrefix}{formattedCurrentScore}{scoreSuffix}";
        }

        if (highScoreText != null)
        {
            string formattedHighScore = scoreData.HighScore.ToString(scoreFormat);
            highScoreText.text = $"{scorePrefix}{formattedHighScore}{scoreSuffix}";
        }
    }

    public void OnPlayerScored(int points)
    {
        AddScore(points);
    }

    public void OnGameOver()
    {
        Debug.Log($"Final Score: {scoreData.CurrentScore}");
        Debug.Log($"High Score: {scoreData.HighScore}");
    }

    public void OnShopOpened()
    {
        Debug.Log("Shop Screen Opened - Updating Score UI");
        UpdateScoreUI();
    }
}

public class ScoreData
{
    public int CurrentScore { get; set; }
    public int HighScore { get; set; }

    public ScoreData()
    {
        CurrentScore = 0;
        HighScore = 0;
    }
}
