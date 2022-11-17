using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float direction = 1;
    public bool isFacingLeft;

    Rigidbody2D body;

    public float movementSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingLeft)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(movementSpeed * direction, 0);
    }
}
