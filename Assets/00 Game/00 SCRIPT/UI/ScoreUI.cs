using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText;

    private void Start()
    {
        currentScoreText.text = "0";
    }


    [System.Obsolete]
    private void Update()
    {
        currentScoreText.text = ScoreManager.Instance.CurrentScore.ToString();
    }
}
