using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    Vector2 inputVec;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    bool canDoubleJump;

    void Awake()
    {
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
        anim.SetBool("isRunning", inputVec.x != 0);
    }

    void OnJump(InputValue value)
    {
        // 이후 점프 처리 로직
        if (anim.GetBool("isGround"))
        {
            anim.SetBool("isJumping", true);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        }
        else if (canDoubleJump)
        {
            canDoubleJump = false;
            anim.SetTrigger("doubleJump");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Terrain"))
        {
            anim.SetBool("isGround", true);
            anim.SetBool("isJumping", false);
            canDoubleJump = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Terrain"))
        {
            anim.SetBool("isGround", false);
        }
    }

    // idle   : 땅에 있고 안움직임
    // 뛰기    : 땅에 있고 움직임
    // 점프    : 땅에 있고 점프함
    // 더블점프 : 땅에 없고 점프했고 더블점프 안했고 점프함
    // 떨어지기 : 땅에 없고 점프 안함
}