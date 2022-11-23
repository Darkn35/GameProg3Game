using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontal;
    float vertical;
    float moveLimit = 0.7f;

    public bool isMoving;
    private bool isDiving;

    Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private PlayerCollision playerCollision;
    private PlayerAnimations playerAnim;

    public float movementSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollision = GetComponent<PlayerCollision>();
        playerAnim = GetComponent<PlayerAnimations>();
        isDiving = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        FlipSprite();
        DiveCheck();
    }

    void DiveCheck() // While optimize later
    {
        if (!playerCollision.isGrounded && vertical < 0)
        {
            playerAnim.SetAnimStateBool("isDiving", true);
            isDiving = true;
        }
        else if (!playerCollision.isGrounded && vertical >= 0)
        {
            playerAnim.SetAnimStateBool("isFlying", true);
            playerAnim.SetAnimStateBool("isDiving", false);
            isDiving = false;
        }
    }

    void FlipSprite() // Will optimize later when assets are created
    {
        if (horizontal > 0 && (playerCollision.isGrounded)) 
        {
            spriteRenderer.flipX = false;
            return;
        }
        else if (horizontal < 0 && (playerCollision.isGrounded))
        {
            spriteRenderer.flipX = true;
            return;
        }

        if (horizontal > 0 && isDiving)
        {
            spriteRenderer.flipX = false;
            return;
        }
        else if (horizontal < 0 && isDiving)
        {
            spriteRenderer.flipX = true;
            return;
        }

        if (horizontal > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimit;
            vertical *= moveLimit;
        }
        body.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);

        if (body.IsSleeping())
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
}
