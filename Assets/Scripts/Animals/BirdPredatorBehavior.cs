using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPredatorBehavior : MonoBehaviour
{
    [SerializeField] private BirdPredatorMovement birdPred;

    public float minWaitTime;
    public float maxWaitTime;

    public float numberOfCycles; 
    public bool isRandom;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int RandomInt() // Choose which branch to perch on
    {
        int max = birdPred.branchArray.Length;
        int i = Random.Range(0, max);
        return i;
    }

    float RandomFloat()
    {
        float i = Random.Range(minWaitTime, maxWaitTime);
        return i;
    }
}
