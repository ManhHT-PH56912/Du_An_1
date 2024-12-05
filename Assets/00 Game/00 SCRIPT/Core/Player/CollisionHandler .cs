using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private int scoreValue = 2; // Giá trị điểm cộng thêm khi va chạm

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra va chạm với đối tượng có Tag "Coins"
        if (collision.CompareTag("Coins"))
        {
            GameManager.Instance.OnPlayerScored(scoreValue);
        }
    }
}
