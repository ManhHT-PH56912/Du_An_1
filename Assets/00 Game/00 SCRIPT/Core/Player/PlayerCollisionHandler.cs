using UnityEngine;
using Consts;

namespace Player
{
    public partial class PlayerCollisionHandler : MonoBehaviour
    {
        private Rigidbody2D rb;

        private PlayerHealth health;
        private EnemyHealth enemyHealth;
        [SerializeField] int damagePlayer = 50;

        [SerializeField] int damage = 2;        // Số máu bị trừ khi chạm nước

        [SerializeField] float bounceForce = 5f; // Lực bật lên khi chạm nước



        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            health = GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
        }

        [System.Obsolete]
        private void OnCollisionEnter2D(Collision2D collision)
        {
            HandleCollision(collision.gameObject);

            if (collision.gameObject.CompareTag(Tags.ENEMY_TAGS))
            {
                // health.TakeDamage(damage);
                enemyHealth.TakeDamageEnemy(damagePlayer);
            }
        }

        [System.Obsolete]
        private void HandleCollision(GameObject collisionObject)
        {
            // Kiểm tra đối tượng va chạm có tag là "Water"
            if (collisionObject.CompareTag(Tags.WATER_TAG))
            {
                // Trừ máu của Player
                health.TakeDamage(damage);

                // Dẩy Player lên cao
                if (rb != null)
                {
                    rb.velocity = new Vector2(rb.velocity.x, bounceForce);
                }

                // Kiểm tra nếu máu <= 0
                if (health.GetHealthPlayer() <= 0)
                {
                    // Player die
                }
            }
        }
    }
}
