using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth;
    public float currentHealth;
    public int speed;
    public int jumpSpeed;
    private bool canTakeDamage = true;
    public bool facingRight = true;
    private Vector3 verticalVelocity = Vector3.zero;
    private float horizontalMove;
    private bool isJumping = false;
    private bool isGrounded = true;
    public LayerMask GroundLayer;
    public LayerMask SpikesLayer;
    private CircleCollider2D cc;
    private Rigidbody2D rb;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();

        Application.targetFrameRate = 60;

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        animator.SetFloat("vertSpeed", rb.velocity.y);

        animator.SetBool("isJumping", !isGrounded);

        animator.SetBool("gotDamage", !canTakeDamage);

        if (isJumping)
        {
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

        if (cc.IsTouchingLayers(GroundLayer.value))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (cc.IsTouchingLayers(SpikesLayer.value))
        {
            if (canTakeDamage)
            {
                GetDamage();
                StartCoroutine(damageTimer());
            }

        }
    }

    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }

    void GetDamage()
    {
        currentHealth -= 10;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
            return;
        }
        rb.AddForce(new Vector2(rb.velocity.x, 400));
    }

    void Die()
    {
        rb.position = new Vector2(-5, -1.433f);
        currentHealth = maxHealth;
    }
    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    void PlayerInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (isGrounded)
        {
            isJumping = Input.GetButtonDown("Jump");
        }
    }

}