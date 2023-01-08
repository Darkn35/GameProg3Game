using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegotiableCollider : MonoBehaviour
{
    [SerializeField] private UIFadeInOut fadeUI;
    [SerializeField] private SleepTimer sleepTime;
    private NegotiableBehavior negotiableBehavior;

    private GameObject branch;
    private GameObject animal;
    public GameObject requestedObj;
    public TreeBehavior tree;

    private bool isContent = false;
    private bool isPlayerHere;

    public float sleepMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        negotiableBehavior = GetComponentInParent<NegotiableBehavior>();
        animal = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isContent)
        {
            StartCoroutine(requestedObj.GetComponent<SpriteFade>().FadeOut());
            StartCoroutine(animal.GetComponent<SpriteFade>().FadeOut());
            Invoke("FadeAway", 1f);
        }
    }

    private void FadeAway()
    {
        sleepTime.sleepTimeMultiplier = sleepMultiplier;
        Destroy(requestedObj);
        animal.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Branch"))
        {
            branch = collision.gameObject;
        }

        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            negotiableBehavior.CheckForItem(collision, "enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            fadeUI.HideUI();
            isPlayerHere = false;
        }

        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            negotiableBehavior.CheckForItem(collision, "exit");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (negotiableBehavior.animalType)
        {
            case NegotiableBehavior.NegotiableAnimals.Weasel:
                {
                    if (collision.gameObject.tag.Equals("Player"))
                    {
                        isPlayerHere = true;
                    }

                    if (collision.gameObject == requestedObj && isPlayerHere)
                    {
                        isContent = true;


                        if (!tree.isSafe)
                        {
                            tree.SnakeOffTree();
                        }
                        else
                        {
                            tree.isSafe = true;
                        }
                    }
                }
                break;
            default:
                {
                    bool isPlayerHere = branch.GetComponent<BranchCollision>().isPlayerHere;

                    if (collision.gameObject == requestedObj && isPlayerHere)
                    {
                        isContent = true;
                    }
                }
                break;
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            fadeUI.ShowUI();
        }
    }
}