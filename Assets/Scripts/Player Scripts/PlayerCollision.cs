using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerAnimations playerAnimations;
    [SerializeField] private SleepTimer timeSlider;
    //[SerializeField] private FruitListIndex fruitList;
    [SerializeField] private PlayerInteractionBehavior buttonUI;
    public bool isGrounded;

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D hitPos in collision.contacts)
        {
            if (hitPos.normal.y > 0)
            {
                if (collision.gameObject.tag.Equals("EInteractable"))
                {
                    collision.gameObject.GetComponent<ObjectBehavior>().canBePicked = true;
                    buttonUI.ShowUIButton();

                    return;
                }
                playerAnimations.SetAnimStateBool("isIdle", true);
                playerAnimations.SetAnimStateBool("isFlying", false);
                playerAnimations.SetAnimStateBool("isDiving", false);
                isGrounded = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerAnimations.SetAnimStateBool("isIdle", false);
        playerAnimations.SetAnimStateBool("isFlying", true);
        isGrounded = false;

        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            collision.gameObject.GetComponent<ObjectBehavior>().canBePicked = false;
            buttonUI.HideUIButton();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            timeSlider.sleepTime = 0f;
        }
    }
}
