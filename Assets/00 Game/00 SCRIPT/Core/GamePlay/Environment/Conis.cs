using UnityEngine;

public class Conis : MonoBehaviour
{

    [SerializeField] private int scoreValue = 2; // Giá trị điểm cộng thêm khi va chạm

    public AudioClip coinSound;  // Âm thanh khi va chạm với đồng xu

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Phát âm thanh khi va chạm
            AudioManager.Instance.PlaySFX(coinSound);
            ScoreManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);  // Hủy đồng xu sau khi va chạm
        }
    }
}