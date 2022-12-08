using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectsSpawn : MonoBehaviour
{
    //[SerializeField] private FruitListIndex fruitList;
    [Header("Falling Objects Prefabs")]
    public GameObject fruitPrefab;
    public GameObject mushroomPrefab;
    public GameObject branchPrefab;
    public GameObject nutPrefab;

    [Header("X Axis Spawn Settings")]
    public Transform posLeft;
    public Transform posRight;
    public Transform posUp;

    [Header("Delay Settings")]
    //public float minDelay;
    //public float maxDelay;
    public float timeToStart;
    public float repeatTime;

    [Header("Falling Object Velocity")]
    private bool isFacingLeft;
    public float minDirectionSpeed;
    public float maxDirectionSpeed;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", timeToStart, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnObject();
    }

    void SpawnObject()
    {
        //StartCoroutine(CheckIfActive());
        GameObject fallObject;
        fallObject = Instantiate(prefabRng(), new Vector3(ChoosePosX(), posUp.position.y, 0), Quaternion.identity);
        Rigidbody2D rb = fallObject.GetComponent<Rigidbody2D>();

        float rotation;

        if (isFacingLeft)
        {
            rotation = 25f;
        }
        else
        {
            rotation = -25f;
        }

        rb.AddTorque(rotation, ForceMode2D.Impulse);
        rb.AddForce(new Vector2(ChooseSpeed(), 0f), ForceMode2D.Impulse);
    }

    GameObject prefabRng()
    {
        GameObject randomObject;

        float randomType = Random.Range(0.0f, 1.0f);

        if (randomType >= 0.0f && randomType <= 0.20f) // 20%
        {
            randomObject = mushroomPrefab;
        }
        else if (randomType >= 0.20f && randomType <= 0.50f) // 30%
        {
            randomObject = nutPrefab;
        }
        else if (randomType >= 0.50f && randomType <= 0.9f) // 40%
        {
            randomObject = branchPrefab;
        }
        else // 10%
        {
            randomObject = fruitPrefab;
        }

        return randomObject;
    }

    float ChoosePosX()
    {
        float x = Random.Range(posLeft.position.x, posRight.position.x);

        if (x > ((posLeft.position.x + posRight.position.x) / 2))
        {
            isFacingLeft = false;
        }
        else
        {
            isFacingLeft = true;
        }
        return x;
    }

    float ChooseSpeed()
    {
        float speed = Random.Range(minDirectionSpeed, maxDirectionSpeed + 1);

        if (isFacingLeft)
        {
            speed *= 1;
        }
        else
        {
            speed *= -1;
        }

        return speed;
    }
}
