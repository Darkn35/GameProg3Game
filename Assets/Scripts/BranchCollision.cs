using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCollision : MonoBehaviour
{
    [SerializeField] private SleepTimer timeSlider;
    [SerializeField] private UIFadeInOut UIFade;
    [SerializeField] private FruitListIndex fruitList;
    private BoxCollider2D boxCollider;
    private bool canSleep = true;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
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

                if (hitPos.normal.y < 0)
                {
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
        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            fruitList.fruit[fruitList.listIndex(collision)].onBranch = true;
            if (fruitList.fruit[fruitList.listIndex(collision)].isMushroom)
            {
                canSleep = false;
                //UIFade.HideUI();
                //timeSlider.ResetTime();
            }
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("EInteractable"))
    //    {
    //        fruitList.fruit[fruitList.listIndex(collision)].onBranch = true;
    //        if (fruitList.fruit[fruitList.listIndex(collision)].isMushroom)
    //        {
    //            canSleep = false;
    //            UIFade.HideUI();
    //            timeSlider.ResetTime();
    //        }
    //    }
    //}

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
            UIFade.HideUI();
            timeSlider.ResetTime();
        }

        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            fruitList.fruit[fruitList.listIndex(collision)].onBranch = false;
            if (fruitList.fruit[fruitList.listIndex(collision)].isMushroom)
            {
                canSleep = true;
            }
        }
    }
}
