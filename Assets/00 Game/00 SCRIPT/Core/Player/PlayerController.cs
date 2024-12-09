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

        [Header("----- Ground Check")]
        [SerializeField] private Transform groundCheckPos;
        [SerializeField] private Vector2 groundCheckSize = new(0.2f, 0.2f);
        [SerializeField] private LayerMask groundLayer;

        [Header("----- Gravity")]
        [SerializeField] private float baseGravity = 2;
        [SerializeField] private float maxFallSpeed = 10;
        [SerializeField] private float fallSpeedMultiplier = 2;

        private static readonly int IdleHash = Animator.StringToHash("Idle");
        private static readonly int RunHash = Animator.StringToHash("Run");
        private static readonly int JumpHash = Animator.StringToHash("Jump");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        private static readonly int KickUpHash = Animator.StringToHash("KickUp");
        private static readonly int KickDownHash = Animator.StringToHash("KickDown");

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            groundLayer = Layers.ground;
        }

        [System.Obsolete]
        private void FixedUpdate()
        {
            MovePlayer();
            HandleGravity();
            FlipCharacter();

            UpdateAnimations();
        }

        private void MovePlayer()
        {
            rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
        }

        private void HandleGravity()
        {
            if (rb.linearVelocity.y > 0.01f) // Nhảy lên
            {
                rb.gravityScale = baseGravity;
                animator.SetTrigger(KickUpHash); // KickUp khi nhảy lên
            }
            else if (rb.linearVelocity.y < -0.01f) // Rơi xuống
            {
                rb.gravityScale = baseGravity * fallSpeedMultiplier;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -maxFallSpeed));
                animator.SetTrigger(KickDownHash); // KickDown khi rơi xuống
            }
            else // Đứng trên mặt đất
            {
                rb.gravityScale = baseGravity;
            }
        }

        private void FlipCharacter()
        {
            if ((isFacingRight && horizontalMovement < 0) || (!isFacingRight && horizontalMovement > 0))
            {
                isFacingRight = !isFacingRight;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }

        private void UpdateAnimations()
        {
            bool isMoving = Mathf.Abs(horizontalMovement) > 0.01f;
            animator.SetBool(RunHash, isMoving);

            if (rb.linearVelocity.y > 0.01f) // KickUp khi nhảy lên
            {
                animator.SetTrigger(KickUpHash);
            }
            else if (rb.linearVelocity.y < -0.01f) // KickDown khi rơi xuống
            {
                animator.SetTrigger(KickDownHash);
            }

            animator.SetFloat("yVelocity", rb.linearVelocity.y);
        }

        public void Move(InputAction.CallbackContext context)
        {
            horizontalMovement = context.ReadValue<Vector2>().x;

            if (context.canceled)
            {
                horizontalMovement = 0f;
            }
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed && IsGrounded())
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
                animator.SetTrigger(JumpHash);
            }

            if (context.canceled && rb.linearVelocity.y > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            }
        }


        public void Attack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                animator.SetTrigger(AttackHash);
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
