using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour
{
    public Transform posLeft;
    public Transform posRight;
    public Transform posUp;
    public Transform posDown;

    public bool isFacingLeft;

    public float minDelay;
    public float maxDelay;

    public GameObject[] birdObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckIfActive());
    }

    IEnumerator CheckIfActive()
    {
        float seconds = Random.Range(minDelay, maxDelay + 1);

        WaitForSeconds wait = new WaitForSeconds(seconds);
        for (int i = 0; i < birdObjects.Length; i++)
        {
            if (!birdObjects[i].activeInHierarchy)
            {
                birdObjects[i].SetActive(true);
                MoveToPos(ChoosePosX(), ChoosePosY(), birdObjects, i);
            }
            yield return wait;
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

        gameObject[index].GetComponent<BirdMovement>().isFacingLeft = isFacingLeft;
    }
}
