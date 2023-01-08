using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float direction;
    public bool isFacingLeft;
    
    [System.Serializable]
    public enum EnemyAnimals
    {
        Bird, Fox, Snake
    }

    [SerializeField] public EnemyAnimals animalType;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    public float movementSpeed = 10.0f;

    public float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingLeft)
        {
            direction = -1;

            if ((animalType == EnemyAnimals.Bird))
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            direction = 1;

            if ((animalType == EnemyAnimals.Bird))
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
    }


    public IEnumerator Startled()
    {
        movementSpeed *= 2;
        yield return new WaitForSeconds(maxTime);
        movementSpeed /= 2;
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(movementSpeed * direction, 0);
    }
}
