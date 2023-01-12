using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCollision : MonoBehaviour
{
    [SerializeField] private ObjectAnimations playerAnim;
    [SerializeField] private PlayerCollision playerCol;
    [SerializeField] private SleepTimer timeSlider;
    [SerializeField] private UIFadeInOut UIFade;
    //[SerializeField] private FruitListIndex fruitList;
    private BoxCollider2D boxCollider;
    public bool canSleep;
    public bool isScared;
    public bool isPlayerHere;
    private bool isCarrying;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isPlayerHere)
        {
            // Need to optimize later
            
            if (playerCol.isScared || isScared)
            {
                playerAnim.SetAnimStateBool("isScared", true);
                UIFade.HideUI();
                timeSlider.ResetTime();
            }
            else
            {
                playerAnim.SetAnimStateBool("isScared", false);
                if (canSleep)
                {
                    UIFade.ShowUI();
                    timeSlider.StartTime();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            foreach(ContactPoint2D hitPos in collision.contacts)
            {
                if (hitPos.normal.y > 0)
                {
                    boxCollider.isTrigger = true;
                    return;
                }
            }
        }

        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            collision.gameObject.GetComponent<ObjectBehavior>().onBranch = true;
            if (collision.gameObject.GetComponent<ObjectBehavior>().onBranch && collision.gameObject.GetComponent<ObjectBehavior>().isMushroom)
            {
                if (isPlayerHere)
                {
                    playerCol.isScared = true;
                    canSleep = false;
                    UIFade.HideUI();
                    timeSlider.ResetTime();
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            foreach (ContactPoint2D hitPos in collision.contacts)
            {
                if (hitPos.normal.y < 0)
                {
                    isPlayerHere = true;
                    if (canSleep)
                    {
                        //UIFade.ShowUI();
                        //timeSlider.StartTime();
                    }
                    else
                    {
                        //UIFade.HideUI();
                        //timeSlider.ResetTime();
                        //Debug.Log("Can't sleep");
                    }
                    return;
                }
            }
        }

        if (collision.gameObject.tag.Equals("Negotiable"))
        {
            canSleep = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            if (collision.gameObject.GetComponent<HingeJoint2D>() != null)
            {
                Debug.Log("hinge joint detected");
                isCarrying = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (isCarrying)
            {
                return;
            }
            else
            {
                boxCollider.isTrigger = false;
            }
        }

        if (collision.gameObject.tag.Equals("EInteractable") && isCarrying)
        {
            isCarrying = false;
            boxCollider.isTrigger = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isPlayerHere = false;
            UIFade.HideUI();
            timeSlider.ResetTime();
        }

        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            collision.gameObject.GetComponent<ObjectBehavior>().onBranch = false;
            if (collision.gameObject.GetComponent<ObjectBehavior>().isMushroom)
            {
                playerCol.isScared = false;
                canSleep = true;
            }
        }

        if (collision.gameObject.tag.Equals("Negotiable"))
        {
            canSleep = true;
        }
    }
}
