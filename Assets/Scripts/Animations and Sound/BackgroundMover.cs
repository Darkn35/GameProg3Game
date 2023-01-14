using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    private ObjectAnimations animations;
    private Transform originalTransform;

    // Start is called before the first frame update
    void Start()
    {
        animations = GetComponent<ObjectAnimations>();

        originalTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void MoveBackgroundUp()
    //{
    //    animations.SetAnimStateTrig("MoveUp");
    //}

}
