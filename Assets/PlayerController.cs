using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int jumpSpeed;
    private Vector3 verticalVelocity = Vector3.zero;
    private float horizontalMove;
    private bool isJumping = false;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (isJumping) {
            // rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector2(rb.velocity.x, jumpSpeed), ref verticalVelocity, 2f);
            // isJumping = false;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
        }

    }

    void PlayerInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        isJumping = Input.GetButtonDown("Jump");
    }

    // void FixedUpdate()
    // {


    // }

}