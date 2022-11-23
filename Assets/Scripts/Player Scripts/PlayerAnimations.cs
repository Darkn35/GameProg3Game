using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnimStateTrig(string anim)
    {
        //playerAnim.SetBool(anim, isTrue);
        playerAnim.SetTrigger(anim);
    }

    public void SetAnimStateBool(string anim, bool isTrue)
    {
        playerAnim.SetBool(anim, isTrue);
    }
}
