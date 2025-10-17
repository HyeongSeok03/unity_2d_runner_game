using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    Vector2 inputVec;
    WallCheck wc;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    bool canDoubleJump = false;
    bool isGround = false;

    void Awake()
    {
        wc = GetComponentInChildren<WallCheck>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(inputVec.x * speed, rb.linearVelocity.y);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
        sr.flipX = (inputVec.x != 0) ? inputVec.x < 0 : sr.flipX;
        anim.SetBool("isWalking", inputVec.x != 0);
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            if (isGround)
            {
                anim.SetTrigger("jump");
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
            }
            else if (wc.isWall)
            {
                rb.AddForce(new Vector2(-jumpSpeed, jumpSpeed), ForceMode2D.Impulse);
            }
            else if (canDoubleJump)
            {
                anim.SetTrigger("doubleJump");
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
                canDoubleJump = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Terrain"))
        {
            isGround = true;
            anim.SetBool("isGround", true);
            canDoubleJump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Terrain"))
        { 
            isGround = false;
            anim.SetBool("isGround", false);
        }
    }
}
