using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetSmoothing;

    public float minXPos;
    public float maxXPos;
    private bool isAtLevelEdge = false;
    private Vector3 playerPosition;

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        DetectLevelEdge();
    }

    void DetectLevelEdge()
    {
        if (playerPosition.x >= maxXPos || playerPosition.x <= minXPos)
        {
            isAtLevelEdge = true;
        }
        else
        {
            isAtLevelEdge = false;
        }
    }

    void MoveCamera()
    {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(player.transform.position.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(player.transform.position.x - offset, playerPosition.y, playerPosition.z);
        }

        if (!isAtLevelEdge)
        {
            transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        }
    }
}
