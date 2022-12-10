using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider;
    private new Camera camera;
    //private Vector2 velocity;

    private float dirX = 0f;
    private float moveSpeed = 5.5f;
    private float jumpForce = 20f;
    private float deltax = 9f;



    [SerializeField] private LayerMask jumpableGround;
    //enumeration type (or enum type) is a value type defined by a set of named constants of the underlying integral numeric type
    private enum MovementState { idle, running, jumping, dead }

    private void Awake()
    {
        camera = Camera.main;
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
            Vector2 position = transform.position;
            position += rb.velocity * Time.fixedDeltaTime;
            Debug.Log(lastLeft);
            // clamp within the screen bounds
            float leftEdge = Mathf.Max(position.x - deltax, lastLeft);
            lastLeft = leftEdge;
            float rightEdge = position.x + deltax;
            if (position.x > leftEdge && position.x < rightEdge) { 
                rb.velocity = new Vector3(rb.velocity.x, jumpForce);
            }

        }
        UpdateAnimationState();
    }
    float lastLeft = float.MinValue;
    private void FixedUpdate()
    {
        // move mario based on his velocity
        //position.x = Mathf.Clamp(position.x, leftEdge, rightEdge);
        //Debug.Log(lastLeft + ", " + leftEdge + "x = "+ position.x);

        //rb.MovePosition(position);
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
