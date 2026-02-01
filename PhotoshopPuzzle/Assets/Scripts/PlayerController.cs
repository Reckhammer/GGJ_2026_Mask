using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
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

    [Header("SFX")]
    public AudioClip jumpSFX;
    public AudioClip deathSFX;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AudioSource audioSource;

    public event Action PlayerDied;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Debug Reset"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetButtonDown("Debug Return"))
            SceneManager.LoadScene("MainMenu");

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
        if (audioSource != null)
            audioSource.PlayOneShot(jumpSFX);

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        jumpCount--;
    }

    private void ResetJumpParams()
    {
        isGrounded = true;
        jumpCount = maxJumpCount;
    }

    public void Death()
    {
        // Play Death Anim
        if (animator != null)
        {
            animator.SetBool("Dead", true);
        }

        if (audioSource != null)
            audioSource.PlayOneShot(deathSFX);

        // Disable Player Movement
        canMove = false;
        isGrounded = false;

        StartCoroutine(DeathSequence());

        PlayerDied?.Invoke();
    }

    private IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void CheckGrounded()
    {
        bool prevGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (!prevGrounded && isGrounded)
            ResetJumpParams();
    }
}
