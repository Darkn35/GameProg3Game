using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPredatorBehavior : MonoBehaviour
{
    [Header("Chance to perch or fly away.")]
    [Range(0.01f, 1f)]
    public float perchProbability;
    [Range(0.01f, 1f)]
    public float flyProbability;
    [Tooltip("Total number of cycles before destroyed or unactivated.")]
    public int numOfCycles;
    [Tooltip("Increases when it hits a waypoint.")]
    public int currentNum;

    private float diveSpeed;

    [Header("Scripts")]
    [SerializeField] private BirdPredatorMovement birdPred;
    [SerializeField] private ObjectAnimations anim;

    // Start is called before the first frame update
    void Start()
    {
        diveSpeed = birdPred.diveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool RandomChance(string typeOfProbability)
    {
        float x = Random.Range(0.01f, 1.0f);

        if (x >= 0.0f && x <= ChooseProbability(typeOfProbability))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private float ChooseProbability(string typeOfProbability)
    {
        if (typeOfProbability == "perch")
        {
            return perchProbability;
        }    
        else
        {
            return flyProbability;
        }
    }

    public void PerchChance()
    {
        currentNum++;

        if (currentNum >= numOfCycles)
        {
            this.gameObject.SetActive(false);
        }

        birdPred.isFlying = !RandomChance("perch");
    }

    public Vector3 targetPos(string actionName)
    {
        if (actionName == "perch")
        {
            int max = birdPred.branchArray.Length;
            int i = Random.Range(0, max);

            birdPred.hasChosenBranch = true;

            birdPred.diveSpeed = diveSpeed;

            GameObject chosenBranch = birdPred.branchArray[i];

            anim.SetAnimStateBool("isFlying", false);
            anim.SetAnimStateBool("isDiving", true);

            return new Vector3(chosenBranch.transform.position.x + birdPred.branchXAxisOffset, chosenBranch.transform.position.y + birdPred.branchYAxisOffset, chosenBranch.transform.position.z);
        }
        else if (actionName == "goBack")
        {
            int i = Random.Range(0, birdPred.waypoint.Length);
            birdPred.hasChosenWaypoint = true;
            birdPred.isGoingBack = true;
            birdPred.diveSpeed = 1f;

            switch (i) 
            {
                case 0:
                    {
                        //birdPred.spriteRenderer.flipX = false;
                        birdPred.direction = 1;
                    }
                    break;
                case 1:
                    {
                        //birdPred.spriteRenderer.flipX = true;
                        birdPred.direction = -1;
                    }
                    break;
                default:
                    {
                        Debug.Log("Errror");
                    }
                    break;
            }

            GameObject wayPoint = birdPred.waypoint[i];

            anim.SetAnimStateBool("isFlying", true);
            anim.SetAnimStateBool("isIdle", false);

            return new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y, wayPoint.transform.position.z);
        }
        return new Vector3(0, 0, 0);
    }
}
