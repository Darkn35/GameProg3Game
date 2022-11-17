using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontal;
    float vertical;
    float moveLimit = 0.7f;

    public bool isMoving;

    Rigidbody2D body;

    public float movementSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
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
