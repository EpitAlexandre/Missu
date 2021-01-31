using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float JumpForce;
    public float WallBounce;

    private bool isJumping;
    private bool isGrounded;
    private bool isOnWallRight;
    private bool isOnWallLeft;
    private bool isBounced;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform WallCheckLeft;
    public Transform WallCheckRight;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;



    void Update()
    {

        isOnWallRight = Physics2D.OverlapPoint(WallCheckRight.position);
        isOnWallLeft = Physics2D.OverlapPoint(WallCheckLeft.position);
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float bounce = WallBounce * Time.deltaTime;
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if(isOnWallRight || isOnWallLeft)
        {
            isBounced = true;
            float direction;
            if(isOnWallRight)
                direction = -1;
            else
                direction = 1;
            BounceWall(bounce, direction);    
        }

        if (horizontalMovement < 10)
            isBounced = false;

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        float open = 0;

        float way = 0;

        if(isBounced)

            Moveplayer(horizontalMovement);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity) ;
    }

    void BounceWall(float _bounce, float _direction)
    {
        Vector3 targetVelocity = new Vector2(_bounce  * _direction, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }

    void Moveplayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    
        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, JumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if(_velocity>0.1f)
        {
            spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
