using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPredatorMovement : MonoBehaviour
{
    public float direction;
    public float flightDistance;
    public float speed;

    public GameObject[] branchArray;
    public Transform[] branchPosArray;

    public bool isFlying = true;
    private Transform birdTransform;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        birdTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        direction = -1; // Optimize when assets arrive
    }

    private void FixedUpdate()
    {
        if (isFlying)
        {
            Fly();
        }
    }

    public void MoveToBranch()
    {
       
    }

    public void Flip()
    {
        if (direction < 0)
        {
            direction = 1;
            spriteRenderer.flipX = true;
        }
        else
        {
            direction = -1;
            spriteRenderer.flipX = false;
        }
    }

    void Fly()
    {
        birdTransform.Translate(speed * direction * Time.deltaTime, 0f, 0f);
    }
}
