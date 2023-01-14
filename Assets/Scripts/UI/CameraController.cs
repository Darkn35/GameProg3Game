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

        if (playerPosition.x >= maxXPos)
        {
            //transform.position = new Vector3(maxXPos, transform.position.y, transform.position.z);
            isAtLevelEdge = true;
        }
        else if (playerPosition.x <= minXPos)
        {
            //transform.position = new Vector3(minXPos, transform.position.y, transform.position.z);
            isAtLevelEdge = true;
        }
        else
        {
            isAtLevelEdge = false;
        }

        if (!isAtLevelEdge)
        {
            transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        }
    }
}
