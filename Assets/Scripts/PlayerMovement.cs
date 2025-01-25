using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 4f;
    public float jumpingPower = 6f;
    private bool isFacingRight = true;
    private bool isWalking;
    private bool isIdle;
    private bool isJumping;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;
    public Animator anim;

    // Update is called once per frame
    public void Start()
    {
    }
    void Update()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("isJumping", isJumping);
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            isJumping = true;
            isIdle = false;
            isWalking = false;
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
             isJumping = true;
            isIdle = false;
            isWalking = false;
        }
       
        if(!Input.anyKeyDown)
        {
            isIdle = true;  
            isWalking = false;
            isJumping = false;

        }
        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            Debug.Log("Burger");
            isWalking = true;
            isIdle = false;

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

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


}
