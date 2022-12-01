using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectsSpawn : MonoBehaviour
{
    [SerializeField] private FruitListIndex fruitList;
    public Transform posLeft;
    public Transform posRight;
    public Transform posUp;

    private bool isFacingLeft;
    public float minDelay;
    public float maxDelay;

    public float minDirectionSpeed;
    public float maxDirectionSpeed;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        StartCoroutine(CheckIfActive());
    }

    IEnumerator CheckIfActive()
    {
        float seconds = Random.Range(minDelay, maxDelay + 1);
        WaitForSeconds wait = new WaitForSeconds(seconds);

        for (int i = 0; i < fruitList.fruit.Count; i++)
        {
            if (!fruitList.fruit[i].gameObject.activeInHierarchy)
            {
                //if (fruitList.fruit[i].isFruit)
                //{
                //    rngProbability(i);
                //    continue;
                //}
                //else
                //{
                    fruitList.fruit[i].gameObject.SetActive(true);
                    MoveToPos(ChoosePosX(), i);
                //}
            }
            yield return wait;
        }
    }

    //void rngProbability(int index)
    //{
    //    int x = Random.Range(1, 10 + 1);
    //    Debug.Log(x);
    //    if (x >= 6)
    //    {
    //        fruitList.fruit[index].gameObject.SetActive(true);
    //        MoveToPos(ChoosePosX(), index);
    //    }
    //}

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

    void MoveToPos(float x, int index)
    {
        fruitList.fruit[index].transform.position = new Vector3(x, posUp.position.y, 0);
        Rigidbody2D rb = fruitList.fruit[index].gameObject.GetComponent<Rigidbody2D>();

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

}
