using Player;
using UnityEngine;

// Dog
public class EnermyMovement : MonoBehaviour
{
    public float enemySpeed;

    Rigidbody2D enemyRB;
    Animator enemyAnim;

    public GameObject enemyGraphic;
    bool facingRight = false;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;
    private PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.CompareTag(Consts.Tags.PLAYER_TAG))
        {
            playerHealth.TakeDamage(10);
            Destroy(collision.gameObject, 0.5f);
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flip();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            { flip(); }

            canFlip = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if (!facingRight)
                enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            else enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
            enemyAnim.SetBool("Run", true);
            // Set Annim
            Destroy(this.gameObject, 2f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            enemyRB.linearVelocity = new Vector2(0, 0);
            enemyAnim.SetBool("Run", false);
        }
    }

    private void flip()
    {
        if (!canFlip)
            return;
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }
}
