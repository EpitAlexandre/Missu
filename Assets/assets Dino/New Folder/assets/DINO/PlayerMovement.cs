using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float JumpForce;
    public float WallBounce;
    public bool Player1;

    private bool isJumping;
    private bool isGrounded;
    private bool isGrounded2;
    private bool isOnWallRight;
    private bool isOnWallLeft;
    private bool isBounced;
    private bool isBounced2;
    private float add = 0;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform WallCheckLeft;
    public Transform WallCheckRight;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private PlayerMovement controller;
    public Collider2D other;


    void OnTriggerEnter2D(Collider2D test)
    {
        controller = test.GetComponent<PlayerMovement>();

        if ((test.name == "dino" && !Player1) || (test.name == "dino2"  && Player1))
        {
            Debug.Log("Gagné");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.name == "dino") || (col.gameObject.name == "dino2")) {
            Debug.Log("gagné");            
        }
    }

    void Update()
    {

        isOnWallRight = Physics2D.OverlapPoint(WallCheckRight.position);
        isOnWallLeft = Physics2D.OverlapPoint(WallCheckLeft.position);
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float bounce = WallBounce * Time.deltaTime;
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float horizontalMovement2 = moveSpeed * Time.deltaTime * add;

        controller = other.GetComponent<PlayerMovement>();

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

        if (Input.GetKey(KeyCode.C) && !Player1)
            add += 0.01f;
        if (Input.GetKey(KeyCode.X) && !Player1)
            add -= 0.01f;
        if (!Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.C) && !Player1 && !isBounced)
        {
            if (add < 0.05 && add > 0.05)
                add = 0;
            if (add > 0)
                add -= 0.05f;
            if (add < 0)
                add += 0.05f;
        }
        if (add > 1)
            add = 1;
        if (add < -1)
            add = -1;

        if (horizontalMovement == 0 || horizontalMovement2 == 0)
            isBounced = false;

        if(Input.GetButtonDown("Jump") && isGrounded && !Player1)
        {
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && Player1)
        {
            isJumping = true;
        }
        if(Player1)
            Moveplayer(horizontalMovement);
        else if(!Player1)
            MoveSecondPlayer(horizontalMovement2);

        if (add > 0)
            add -= 0.0025f;
        if (add < 0)
            add += 0.0025f;
        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void BounceWall(float _bounce, float _direction)
    {
        Vector3 targetVelocity = new Vector2(_bounce  * _direction, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }

    void MoveSecondPlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    
        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, JumpForce));
            isJumping = false;
        }
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
