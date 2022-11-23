using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerAnimations playerAnimations;
    public bool isGrounded;

    private void Start()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("Branch"))
        {
            playerAnimations.SetAnimStateBool("isIdle", true);
            playerAnimations.SetAnimStateBool("isFlying", false);
            playerAnimations.SetAnimStateBool("isDiving", false);
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerAnimations.SetAnimStateBool("isIdle", false);
        playerAnimations.SetAnimStateBool("isFlying", true);
        isGrounded = false;
    }
}
