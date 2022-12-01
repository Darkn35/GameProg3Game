using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionBehavior : MonoBehaviour
{
    [SerializeField] private UIFadeInOut fadeInOut;
    [SerializeField] private PlayerCollision playerCollision;
    [SerializeField] private FruitListIndex fruitList;

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
        if (collision.gameObject.tag.Equals("EInteractable") && playerCollision.isGrounded)
        {
            if (fruitList.fruit[fruitList.listIndexTrig(collision)].onBranch && fruitList.fruit[fruitList.listIndexTrig(collision)].isFruit)
            {
                fadeInOut.ShowUI();
                fruitList.fruit[fruitList.listIndexTrig(collision)].isInteractable = true;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            if (fruitList.fruit[fruitList.listIndexTrig(collision)].onBranch)
            {
                fadeInOut.HideUI();
                fruitList.fruit[fruitList.listIndexTrig(collision)].isInteractable = false;
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
