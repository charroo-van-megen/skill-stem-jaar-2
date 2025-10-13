using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpTimer : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] float jumpForce = 7f;
    [SerializeField] Transform groundCheck;     // Empty object under the block
    [SerializeField] float groundCheckRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool wasGroundedLastFrame;
    private float jumpTimer = 0f;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the block is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Detect jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Detect when the block leaves the floor
        if (wasGroundedLastFrame && !isGrounded)
        {
            isJumping = true;
            jumpTimer = 0f;
        }

        // Detect when the block lands back
        if (!wasGroundedLastFrame && isGrounded)
        {
            isJumping = false;
            Debug.Log($"Jump time: {jumpTimer:F2} seconds");
        }

        // If jumping, count time in the air
        if (isJumping)
        {
            jumpTimer += Time.deltaTime;
        }

        wasGroundedLastFrame = isGrounded;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
