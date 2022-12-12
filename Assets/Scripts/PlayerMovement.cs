using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider;

    private float dirX = 0f;
    private float moveSpeed = 5.5f;
    private float jumpForce = 20f;



    [SerializeField] private LayerMask jumpableGround;
    //enumeration type (or enum type) is a value type defined by a set of named constants of the underlying integral numeric type
    private enum MovementState { idle, running, jumping, dead }

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);

        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        //else if (rb.velocity.y < -.1f)
        //{
        //    state = MovementState.dead;
        //}

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
