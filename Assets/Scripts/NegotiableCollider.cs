using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegotiableCollider : MonoBehaviour
{
    [SerializeField] private UIFadeInOut fadeUI;
    [SerializeField] private SleepTimer sleepTime;

    private GameObject branch;
    private GameObject requestedObj;
    private GameObject animal;

    public bool isSquirrel;
    public bool isBird;

    private bool isCorrectRequestedObj;
    private bool isContent = false;
    public float sleepMultiplier;

    // Start is called before the first frame update
    void Start()
    {
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

    private void CheckForItem(Collider2D collision, string triggerState)
    {
        if (isSquirrel)
        {
            isCorrectRequestedObj = collision.gameObject.GetComponent<ObjectBehavior>().isNut;
        }
        else if (isBird)
        {
            isCorrectRequestedObj = collision.gameObject.GetComponent<ObjectBehavior>().isFruit;
        }

        if (isCorrectRequestedObj && triggerState == "enter")
        {
            requestedObj = collision.gameObject;
        }
        else if (isCorrectRequestedObj && triggerState == "exit")
        {
            requestedObj = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Branch"))
        {
            branch = collision.gameObject;
        }

        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            CheckForItem(collision, "enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            fadeUI.HideUI();
        }

        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            CheckForItem(collision, "exit");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        bool isPlayerHere = branch.GetComponent<BranchCollision>().isPlayerHere;

        if (collision.gameObject == requestedObj && isPlayerHere)
        {
            isContent = true;
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            fadeUI.ShowUI();
        }
    }
}
