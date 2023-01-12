using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMover : MonoBehaviour
{
    private ObjectAnimations animations;
    private Transform originalTransform;

    // Start is called before the first frame update
    void Start()
    {
        animations = GetComponent<ObjectAnimations>();

        originalTransform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveBackgroundUp()
    {
        animations.SetAnimStateTrig("MoveUp");
    }

    public void ResetPosition()
    {
        this.transform.position = originalTransform.position;
    }
}
