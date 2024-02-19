using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpPower = 15f;
    [SerializeField] private float radiusGroundCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private float wallSlidingSpeed;
    private float h;

    [SerializeField] private int jumpCount;

    [SerializeField] private bool isRun;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isFacingRight;
    [SerializeField] private bool isTouchingWall;
    [SerializeField] private bool isWallSliding;
    [SerializeField] private bool canJump;
    [SerializeField] public bool isGetDame;

    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask ground;
    
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private Transform wallCheckPos;
    private void Awake()
    {
        if (Instance != null && this != Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public LayerMask setGround(LayerMask layer) => ground = layer;

    void Start()
    {
        gameObject.name = "Player";
        anim.SetTrigger("ap");
    }
    void Update()
    {
        MoveInput();
        Update_Anim();
    }
    private void FixedUpdate()
    {
        ApplyMove();
        checkPhysics();
        wallSliding();
    }
    private void MoveInput()
    {
        h = Input.GetAxisRaw("Horizontal");
        if ((h < 0 && isFacingRight) || (h > 0 && !isFacingRight))
            Flip();
        
        if (h != 0) isRun = true;
        else isRun = false;

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }
    private void ApplyMove()
    {
        if(Health.Instance.GetIsInvisible() == false)
        {
            rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);
            if(isWallSliding)
                rb.velocity = new Vector2(rb.velocity.x, -wallSlidingSpeed);
        }
    }
    void Update_Anim()
    {
        anim.SetBool("isRun", isRun);
        anim.SetFloat("y_vel", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isWallSliding", isWallSliding);
    }
    void Jump()
    {
        jumpCount++;
        if (isGrounded == true) jumpCount = 0;
        if (jumpCount < 2) rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        rb.transform.Rotate(0, 180, 0);
    }
    private void wallSliding()
    {
        if(!isGrounded && rb.velocity.y < 0 && isTouchingWall)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }
    private void checkPhysics()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, radiusGroundCheck, ground);
        isTouchingWall = Physics2D.Raycast(wallCheckPos.position, transform.right, wallCheckDistance, ground);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckPos.position, radiusGroundCheck);
        Gizmos.DrawLine(wallCheckPos.position, 
            new Vector3(wallCheckPos.position.x + wallCheckDistance, wallCheckPos.position.y, wallCheckPos.position.z));
    }
    public Animator GetAnimator() => anim;
}
