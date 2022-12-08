using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCollision : MonoBehaviour
{
    [SerializeField] private SleepTimer timeSlider;
    [SerializeField] private UIFadeInOut UIFade;
    //[SerializeField] private FruitListIndex fruitList;
    private BoxCollider2D boxCollider;
    private bool canSleep = true;
    private bool isPlayerHere;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (canSleep && isPlayerHere)
        {
            UIFade.ShowUI();
            timeSlider.StartTime();
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
            if (collision.gameObject.GetComponent<ObjectBehavior>().onBranch)
            {
                if (isPlayerHere)
                {
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
                        UIFade.ShowUI();
                        timeSlider.StartTime();
                    }
                    else
                    {
                        UIFade.HideUI();
                        timeSlider.ResetTime();
                        Debug.Log("Can't sleep");
                    }
                    return;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
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
                canSleep = true;
            }
        }
    }
}
