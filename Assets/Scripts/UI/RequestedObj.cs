using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestedObj : MonoBehaviour
{
    public NegotiableBehavior negotiable;
    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        switch (negotiable.animalType)
        {
            case NegotiableBehavior.NegotiableAnimals.Squirrel:
                {
                    img.sprite = Resources.Load<Sprite>("Sprites/NutAsset");
                }
                break;
            case NegotiableBehavior.NegotiableAnimals.Owl:
                {
                    img.sprite = Resources.Load<Sprite>("Sprites/BranchAsset");
                }
                break;
            case NegotiableBehavior.NegotiableAnimals.Weasel:
                {
                    img.sprite = Resources.Load<Sprite>("Sprites/AppleAsset");
                }
                break;
            default:
                {
                    print("defaulttttt");
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
