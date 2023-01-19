using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnimStateTrig(string anim)
    {
        animator.SetTrigger(anim);
    }

    public void SetAnimStateBool(string anim, bool isTrue)
    {
        animator.SetBool(anim, isTrue);
    }

    public void SetAnimFloat(string anim, float value)
    {
        animator.SetFloat(anim, value);
    }
}
