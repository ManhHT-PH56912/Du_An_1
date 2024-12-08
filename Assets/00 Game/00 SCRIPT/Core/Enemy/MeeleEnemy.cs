using UnityEngine;
using UnityEngine.EventSystems;
using Player;

public class MeeleEnemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTime = Mathf.Infinity;
    private Animator anim;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerLayer = LayerMask.GetMask("Player");
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        cooldownTime += Time.deltaTime;

        //Tan cong khi player lai gan
        if (PlayerInSight())
        {
            if (cooldownTime >= attackCooldown)
            {
                cooldownTime = 0;
                anim.SetTrigger("meleeAttack");
                playerHealth.TakeDamage(damage);
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
            , 0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void TakeDamageEnemy(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
