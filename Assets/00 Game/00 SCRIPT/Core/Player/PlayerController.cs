using UnityEngine;
using UnityEngine.InputSystem;
using Consts;

namespace Player
{
    public partial class PlayerController : MonoBehaviour
    {
        private Rigidbody2D rb;
        private bool isFacingRight = true;
        private Animator animator;

        [Header("----- Movement")]
        [SerializeField] private float moveSpeed;
        private float horizontalMovement;

        [Header("----- Jumping")]
        [SerializeField] private float jumpPower;

        [Header("----- GroundCheck")]
        [SerializeField] private Transform groundCheckPos;
        [SerializeField] private Vector2 groundCheckSize = new(0.2f, 0.2f);
        [SerializeField] private LayerMask groundLayer;

        [Header("----- Gravity")]
        [SerializeField] private float baseGravity = 2;
        [SerializeField] private float maxFallSpeed = 10;
        [SerializeField] private float fallSpeedMultiplier = 2;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            groundLayer = Layers.ground;
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed * Time.fixedDeltaTime, rb.linearVelocity.y);
            HandleGravity();
            Flip();

            animator.SetFloat("yVelocity", rb.linearVelocity.y);
            animator.SetFloat("magnitude", rb.linearVelocity.magnitude);
        }

        private void HandleGravity()
        {
            if (rb.linearVelocity.y < 0)
            {
                rb.gravityScale = baseGravity * fallSpeedMultiplier;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -maxFallSpeed));
            }
            else
            {
                rb.gravityScale = baseGravity;
            }
        }

        public void Move(InputAction.CallbackContext context)
        {
            horizontalMovement = context.ReadValue<Vector2>().x;
            animator.SetFloat("magnitude", rb.linearVelocity.magnitude);

        }

        private void Flip()
        {
            if (isFacingRight && horizontalMovement < 0 || !isFacingRight && horizontalMovement > 0)
            {
                isFacingRight = !isFacingRight;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (IsGrounded())
            {
                if (context.performed)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
                    animator.SetTrigger("Jump");
                }
                else if (context.canceled)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
                }
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0f, groundLayer);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawCube(groundCheckPos.position, groundCheckSize);
        }
    }
}
