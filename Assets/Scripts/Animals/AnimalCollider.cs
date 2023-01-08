using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollider : MonoBehaviour
{
    private AnimalMovement animalMovement;

    public bool isEnemy;
    public bool isFlyingAnimal;

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
        else if (collision.gameObject.tag.Equals("EInteractable") && !isFlyingAnimal)
        {
            switch (animalMovement.animalType)
            {
                case AnimalMovement.EnemyAnimals.Fox:
                    {
                        Startled(collision);
                    }
                    break;
                case AnimalMovement.EnemyAnimals.Snake:
                    {
                        Startled(collision);
                    }
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFlyingAnimal && collision.gameObject.tag.Equals("Tree Trunk"))
        {
            if (animalMovement.animalType == AnimalMovement.EnemyAnimals.Snake)
            {
                if (collision.gameObject.GetComponent<TreeBehavior>().isSafe)
                {
                    animalMovement.isFacingLeft = !animalMovement.isFacingLeft;
                }
                else
                {
                    collision.gameObject.GetComponent<TreeBehavior>().SnakeOnTree();
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    void Startled(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ObjectBehavior>().isMushroom)
        {
            Vector3 dir = collision.transform.position - GetComponentInParent<Transform>().position;

            if (dir.x < 0)
            {
                animalMovement.isFacingLeft = false;
            }
            else
            {
                animalMovement.isFacingLeft = true;
            }
            StartCoroutine(animalMovement.Startled());
        }
    }
}
