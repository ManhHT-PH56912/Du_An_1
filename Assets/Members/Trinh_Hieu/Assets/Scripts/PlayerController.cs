using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance = 1f;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private int jumpCount = 0;
    private bool facingRight = true;

    private Health health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        // Ensure the correct layer mask is set for "Ground" objects
        whatIsGround = LayerMask.GetMask("Ground");
    }

    [System.Obsolete]
    void Update()
    {
        // Move left/right
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Perform Raycast2D to check if the player is grounded
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

        // Reset jump count when grounded
        if (isGrounded)
        {
            jumpCount = 0;
        }

        // Update animator states
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("moveSpeed", Mathf.Abs(moveInput));
        animator.SetInteger("jumpCount", jumpCount);

        // Jump (allow up to 2 jumps in a row, even when not grounded)
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            Jump();
        }

        // Flip character based on movement direction
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    [System.Obsolete]
    void Jump()
    {
        // Apply jump force
        // rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpCount++;

        // Trigger the appropriate animation based on jump count
        if (jumpCount == 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump"); // First jump
        }
        else if (jumpCount == 2)
        {
            animator.SetTrigger("DoubleJumpKick"); // Second jump (double jump)
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is colliding with the ground
        if (collision.gameObject.CompareTag(Consts.Tags.GROUND_TAG))
        {
            isGrounded = true;
        }

        // Check if the player is colliding with an enemy
        if (collision.gameObject.CompareTag(Consts.Tags.ENEMY_TAGS))
        {
            health.TakeDame(10);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
