using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegotiableBehavior : MonoBehaviour
{
    private NegotiableCollider negotiableCollider;

    [System.Serializable]
    public enum NegotiableAnimals
    {
        Squirrel, Weasel, Owl
    }

    [SerializeField] public NegotiableAnimals animalType;

    private bool isCorrectRequestedObj;

    // Start is called before the first frame update
    void Start()
    {
        negotiableCollider = GetComponentInChildren<NegotiableCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckForItem(Collider2D collision, string triggerState)
    {
        switch (animalType)
        {
            case NegotiableAnimals.Squirrel:
                {
                    isCorrectRequestedObj = collision.gameObject.GetComponent<ObjectBehavior>().isNut;
                }
                break;
            case NegotiableAnimals.Owl:
                {
                    isCorrectRequestedObj = collision.gameObject.GetComponent<ObjectBehavior>().isBranch;
                }
                break;
            case NegotiableAnimals.Weasel:
                {
                    isCorrectRequestedObj = collision.gameObject.GetComponent<ObjectBehavior>().isFruit;
                }
                break;
            default:
                {
                    print("defaulttttt");
                }
                break;
        }

        if (isCorrectRequestedObj && triggerState == "enter")
        {
            negotiableCollider.requestedObj = collision.gameObject;
        }
        else if (isCorrectRequestedObj && triggerState == "exit")
        {
            negotiableCollider.requestedObj = null;
        }
    }
}