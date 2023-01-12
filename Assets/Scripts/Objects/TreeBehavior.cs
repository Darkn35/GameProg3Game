using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour
{
    private ObjectAnimations animations;
    public BranchCollision branch;
    public bool isSafe;
    // Start is called before the first frame update
    void Start()
    {
        animations = GetComponent<ObjectAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SnakeOnTree()
    {
        animations.SetAnimStateBool("isSnakeOn", true);
        branch.canSleep = false;
        branch.isScared = true;
        isSafe = false;
    }

    public void SnakeOffTree()
    {
        animations.SetAnimStateBool("isSnakeOn", false);
        branch.canSleep = true;
        branch.isScared = false;
        isSafe = true;
    }
}
