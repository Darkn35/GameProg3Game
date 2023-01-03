using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour
{
    [Header("X/Y Axis Spawn Settings")]
    public Transform posLeft;
    public Transform posRight;
    public Transform posUp;
    public Transform posDown;

    [Header("Settings")]
    public float minDelay;
    public float maxDelay;
    public float probability;
    public bool isFacingLeft;

    [Header("Array of Bird Objects")]
    public GameObject[] birdObjects;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckIfActive", 0f, RandomTime());
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(CheckIfActive());
    }

    void CheckIfActive()
    {
        for (int i = 0; i < birdObjects.Length; i++)
        {
            if (!birdObjects[i].activeInHierarchy)
            {
                if (RandomChance())
                {
                    StartCoroutine(SpawnBird(i));

                }
            }
        }
    }

    //IEnumerator DelayCode(int i)
    //{
    //    float x = RandomTime();
    //    yield return new WaitForSeconds(x);
    //    //SpawnBird(i);

    //}

    IEnumerator SpawnBird(int i)
    {
        float x = RandomTime();
        yield return new WaitForSeconds(x);

        if(!birdObjects[i].activeInHierarchy) 
        // Birds can still be teleported to new positions while active
        {
            birdObjects[i].GetComponent<AnimalDisappear>().Init();
            MoveToPos(ChoosePosX(), ChoosePosY(), birdObjects, i);
            birdObjects[i].SetActive(true);
        }
    }

    float RandomTime()
    {
        float seconds = Random.Range(minDelay, maxDelay + 1);
        return seconds;
    }

    bool RandomChance()
    {
        float x = Random.Range(0.01f, 1.0f);

        if (x >= 0.0f && x <= probability)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    float ChoosePosX()
    {
        int x = Random.Range(1, 3);
        float xPos = 0f;

        switch(x)
        {
            case 1:
                {
                    xPos = posLeft.position.x;
                    isFacingLeft = false;
                }
                break;
            case 2:
                {
                    xPos = posRight.position.x;
                    isFacingLeft = true;
                }
                break;
        }
        return xPos;
    }

    float ChoosePosY()
    {
        float y = Random.Range(posUp.position.y, posDown.position.y + 1);

        return y;
    }

    void MoveToPos(float x, float y, GameObject[] gameObject, int index)
    {
        gameObject[index].transform.position = new Vector3(x, y, 0);

        gameObject[index].GetComponent<AnimalMovement>().isFacingLeft = isFacingLeft;
    }
}
