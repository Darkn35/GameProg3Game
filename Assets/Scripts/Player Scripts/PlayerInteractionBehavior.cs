using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionBehavior : MonoBehaviour
{
    [SerializeField] private UIFadeInOut fadeInOut;
    [SerializeField] private PlayerCollision playerCollision;
    //[SerializeField] private FruitListIndex fruitList;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerCollision.isGrounded)
        {
            if (collision.gameObject.tag.Equals("EInteractable"))
            {
                if (collision.gameObject.GetComponent<ObjectBehavior>().onBranch && collision.gameObject.GetComponent<ObjectBehavior>().isFruit)
                {
                    fadeInOut.ShowUI();
                    collision.gameObject.GetComponent<ObjectBehavior>().isInteractable = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            if (collision.gameObject.GetComponent<ObjectBehavior>().isFruit)
            {
                fadeInOut.HideUI();
                collision.gameObject.GetComponent<ObjectBehavior>().isInteractable = false;
            }
        }
    }

    public void ShowUIButton()
    {
        fadeInOut.ShowUI();
    }

    public void HideUIButton()
    {
        fadeInOut.HideUI();
    }
}
