using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private ObjectAnimations playerAnimations;
    [SerializeField] private SleepTimer timeSlider;
    //[SerializeField] private FruitListIndex fruitList;
    [SerializeField] private PlayerInteractionBehavior buttonUI;
    [SerializeField] private UIFadeInOut UIFade;
    public bool isGrounded;
    public bool isScared;

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
                playerAnimations.SetAnimStateBool("isScared", false);
                playerAnimations.SetAnimStateBool("isFlying", false);
                playerAnimations.SetAnimStateBool("isDiving", false);
                isGrounded = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Added since Rigidbody.IsSleeping() is for some reason not working
        UIFade.HideUI();
        timeSlider.ResetTime();
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
}
