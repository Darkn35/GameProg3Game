using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObj = collision.gameObject;
        if (gameObj.tag.Equals("Predator"))
        {
            bool isBird = gameObj.GetComponent<AnimalMovement>().isBird;
            bool isFacingLeft = gameObj.GetComponent<AnimalMovement>().isFacingLeft;



            if (!isBird)
            {
                if (isFacingLeft)
                {
                    gameObj.GetComponent<AnimalMovement>().isFacingLeft = false;
                }
                else
                {
                    gameObj.GetComponent<AnimalMovement>().isFacingLeft = true;
                }
                StartCoroutine(gameObj.GetComponent<AnimalMovement>().Startled());
            }
        }
    }
}
