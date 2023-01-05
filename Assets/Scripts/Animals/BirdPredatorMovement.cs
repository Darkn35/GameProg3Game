using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPredatorMovement : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private BirdPredatorBehavior birdPred;
    [SerializeField] private ObjectAnimations anim;

    [Header("Movement Settigns")]
    [Tooltip("Positive Value - Facing Right\nNegative Value - Facing Left")]
    public float direction;
    public float speed;

    [Header("Perch Position on Branch Offset")]
    public float branchXAxisOffset;
    public float branchYAxisOffset;

    [Header("GameObject Arrays")]
    public GameObject[] branchArray;
    public GameObject[] waypoint;

    [Header("Boolean Behaviors")]
    public bool isFlying = true;
    public bool isPerched = false;
    public bool hasChosenBranch = false;
    public bool hasChosenWaypoint = false;
    public bool isGoingBack = false;

    private Transform birdTransform;
    private SpriteRenderer spriteRenderer;
    private float change;
    private float timer;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        birdTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        change = speed * Time.deltaTime;
        direction = -1; // Optimize when assets arrive
        timer = 3f;
    }

    private void FixedUpdate()
    {
        //Flip();

        if (isFlying)
        {
            Fly();
        }
        else if (!isFlying && !isPerched)
        {
            if (!hasChosenBranch)
            {
                targetPos = birdPred.targetPos("perch");
            }
            else
            {
                MoveToTargetPos("perch");
            }
        }
        else if (!isFlying && isPerched)
        {
            if (!isGoingBack)
            {
                timer -= Time.deltaTime;

                if (timer < 0)
                {
                    if (birdPred.RandomChance())
                    {
                        targetPos = birdPred.targetPos("goBack");
                        Flip();
                    }
                    timer = 3f;
                }
            }
            else if (isGoingBack)
            {
                MoveToTargetPos("goBack");
            }
        }
    }

    void MoveToTargetPos(string actionName)
    {
        birdTransform.position = Vector3.MoveTowards(birdTransform.position, targetPos, change);

        if (birdTransform.position == targetPos && actionName == "perch")
        {
            anim.SetAnimStateBool("isIdle", true);
            anim.SetAnimStateBool("isDiving", false);

            isPerched = true;
        }
        else if (birdTransform.position == targetPos && actionName == "goBack")
        {
            isPerched = false;
            isGoingBack = false;
            hasChosenBranch = false;
            hasChosenWaypoint = false;
        }
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
        birdTransform.Translate(change * direction, 0f, 0f);
    }
}
