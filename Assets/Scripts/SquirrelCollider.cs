using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelCollider : MonoBehaviour
{
    [SerializeField] private UIFadeInOut fadeUI;
    [SerializeField] private SleepTimer sleepTime;

    private GameObject branch;
    private GameObject nut;
    private GameObject squirrel;
    private bool isNut;
    private bool isContent = false;
    public float sleepMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        squirrel = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isContent)
        {
            StartCoroutine(nut.GetComponent<SpriteFade>().FadeOut());
            StartCoroutine(squirrel.GetComponent<SpriteFade>().FadeOut());
            Invoke("FadeAway", 1f);
        }
    }

    private void FadeAway()
    {
        sleepTime.sleepTimeMultiplier = sleepMultiplier;
        Destroy(nut);
        squirrel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Branch"))
        {
            branch = collision.gameObject;
        }

        if (collision.gameObject.tag.Equals("EInteractable"))
        {
            isNut = collision.gameObject.GetComponent<ObjectBehavior>().isNut;

            if (isNut)
            {
                nut = collision.gameObject;
            }
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
            isNut = collision.gameObject.GetComponent<ObjectBehavior>().isNut;

            if (isNut)
            {
                nut = null;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        bool isPlayerHere = branch.GetComponent<BranchCollision>().isPlayerHere;

        if (collision.gameObject == nut && isPlayerHere)
        {
            isContent = true;
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            fadeUI.ShowUI();
        }
    }
}
