using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 4f;
    public float jumpingPower = 6f;
    public bool left = true;
    public bool isWalking;
    public bool isIdle;
    public bool isJumping;
    public bool isGrowing;
    public bool dead;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;
    public Animator anim;

    // Update is called once per frame
    public void Start()
    {
        dead = false;
    }
    void Update()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isGrowing", isGrowing);
        anim.SetBool("Death", dead);


        if (!dead)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                isJumping = true;
                isIdle = false;
                isWalking = false;
                FindFirstObjectByType<AudioManager>().Play("bubblenoise", 1f, 0.3f, false);

            }

            if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
                isJumping = true;
                isIdle = false;
                isWalking = false;
            }

            if (!Input.anyKeyDown)
            {
                isIdle = true;
                isWalking = false;
                isJumping = false;

            }
            if (Input.GetKey("d"))
            {
                isWalking = true;
                isIdle = false;
                FaceDirection(true);


            }
            if (Input.GetKey("a"))
            {
                isWalking = true;
                isIdle = false;
                FaceDirection(false);
            }
        }
        else
        {
            speed = 0f;
            FindFirstObjectByType<AudioManager>().Play("dying", 1f, 0.3f, false);

        }


    }
    private void FixedUpdate()
    {
        float moveSpeed = speed;
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
    }
    
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void FaceDirection(bool isFacingLeft)
    {
        Vector3 localScale = transform.localScale;
        if (isFacingLeft && localScale.x > 0 || !isFacingLeft && localScale.x < 0)
        {
            localScale.x *= -1; // Flip the sprite by reversing the X scale
            transform.localScale = localScale;
        }
    }
}
