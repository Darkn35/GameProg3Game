using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollider : MonoBehaviour
{
    private AnimalMovement animalMovement;

    public bool isEnemy;
    public bool isFox;

    // Start is called before the first frame update
    void Start()
    {
        animalMovement = GetComponentInParent<AnimalMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && isEnemy)
        {
            collision.gameObject.GetComponent<PlayerCollision>().isScared = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && isEnemy)
        {
            collision.gameObject.GetComponent<PlayerCollision>().isScared = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("BirdPredFlip"))
        {
            try
            {
                BirdPredatorMovement birdPredMovement = this.gameObject.GetComponent<BirdPredatorMovement>();
                BirdPredatorBehavior birdPredBehavior = this.gameObject.GetComponent<BirdPredatorBehavior>();

                birdPredMovement.Flip();

                if (!birdPredMovement.isFlying)
                {
                    birdPredMovement.isFlying = true;
                }
                birdPredBehavior.PerchChance();
            }
            catch
            {
                Debug.Log("Errorrrr");
            }
        }

        if (collision.gameObject.tag.Equals("EInteractable") && isFox)
        {
            if (animalMovement.isFox)
            {
                if (collision.gameObject.GetComponent<ObjectBehavior>().isMushroom)
                {
                    Vector3 dir = collision.transform.position - GetComponentInParent<Transform>().position;

                    if (dir.x < 0)
                    {
                        animalMovement.isFacingLeft = true;
                    }
                    else
                    {
                        animalMovement.isFacingLeft = false;
                    }
                    StartCoroutine(animalMovement.Startled());
                }
            }
        }
    }
}
