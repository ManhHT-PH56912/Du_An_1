using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public partial class PlayerCollisionHandler : MonoBehaviour
    {
        private PlayerHealth health;
        public int damage = 10;        // Số máu bị trừ khi chạm nước
        public float bounceForce = 5f; // Lực bật lên khi chạm nước

        private Rigidbody2D rb;

        [SerializeField] private int scoreValue = 2; // Giá trị điểm cộng thêm khi va chạm


        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            health = GetComponent<PlayerHealth>();
        }

        [System.Obsolete]
        private void OnCollisionEnter2D(Collision2D collision)
        {
            HandleCollision(collision.gameObject);

            if (collision.gameObject.CompareTag("Enemy"))
            {
                health.TakeDamage(damage);
            }
        }

        [System.Obsolete]
        private void HandleCollision(GameObject collisionObject)
        {
            // Kiểm tra đối tượng va chạm có tag là "Water"
            if (collisionObject.CompareTag("Water"))
            {
                // Trừ máu của Player
                health.TakeDamage(damage);
                Debug.Log($"Take Damage Player : {health.GetHealthPlayer()}");

                // Dẩy Player lên cao
                if (rb != null)
                {
                    rb.velocity = new Vector2(rb.velocity.x, bounceForce);
                }

                // Kiểm tra nếu máu <= 0
                if (health.GetHealthPlayer() <= 0)
                {
                    // Die Player
                }
            }
        }

        [System.Obsolete]
        private void OnTriggerEnter2D(Collider2D collider)
        {
            HandleCollision(collider.gameObject);

            // Kiểm tra va chạm với đối tượng có Tag "Coins"
            if (collider.CompareTag("Coins"))
            {
                // GameManager.Instance.OnPlayerScored(scoreValue);
            }
        }

    }
}
