using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    public int maxJumpCount;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount;
    private float xInputDir;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public event Action PlayerDied;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        xInputDir = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount > 0) && canMove)
            Jump();

        spriteRenderer.flipX = xInputDir < 0f && canMove;
    }

    private void FixedUpdate()
    {
        if (canMove)
            rb.linearVelocity = new Vector2(xInputDir * moveSpeed, rb.linearVelocity.y);

        if (animator != null)
            animator.SetBool("Move", rb.linearVelocity.magnitude > 0f);
    }

    private void Jump()
    {
        if (animator != null)
            animator.SetTrigger("Jump");

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        jumpCount--;
    }

    private void ResetJumpParams()
    {
        isGrounded = true;
        jumpCount = maxJumpCount;
    }

    private void Death()
    {
        // Play Death Anim
        if (animator != null)
        {
            animator.SetBool("Dead", true);
        }

        // Disable Player Movement
        canMove = false;
        isGrounded = false;

        PlayerDied?.Invoke();
    }

    private void CheckGrounded()
    {
        bool prevGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (!prevGrounded && isGrounded)
            ResetJumpParams();
    }
}
