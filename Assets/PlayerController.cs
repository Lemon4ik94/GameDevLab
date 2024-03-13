using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int jumpSpeed;
    private bool facingRight = true;
    private Vector3 verticalVelocity = Vector3.zero;
    private float horizontalMove;
    private bool isJumping = false;
    private bool isGrounded = true;
    public LayerMask GroundLayer;
    private CircleCollider2D cc;
    private Rigidbody2D rb;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        animator.SetFloat("vertSpeed", rb.velocity.y);

        animator.SetBool("isJumping", !isGrounded);

        if (isJumping) {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
        }

        if (horizontalMove < 0 && facingRight)
        {
            Flip();
        }
        else if (horizontalMove > 0 && !facingRight)
        {
            Flip();
        }

        if (cc.IsTouchingLayers(GroundLayer.value)) {
            isGrounded = true;
            Debug.Log(isGrounded);
        } else {
            isGrounded = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void PlayerInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (isGrounded) {
            isJumping = Input.GetButtonDown("Jump");
        }
    }

    // void FixedUpdate()
    // {
        
    
        

    // }

}