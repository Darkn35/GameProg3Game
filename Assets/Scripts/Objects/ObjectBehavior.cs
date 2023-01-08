using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    public bool canBePicked;
    public bool isInteractable;
    public bool isGrabbed;
    public bool onBranch;
    public bool isFruit;
    public bool isMushroom;
    public bool isNut;
    public bool isBranch;

    public float sleepMultiplier;
    [SerializeField] private SleepTimer sleepTimer;
    [SerializeField] private PlayerInteractionBehavior buttonUI;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        GameObject player = GameObject.Find("Player");
        sleepTimer = player.GetComponentInChildren<SleepTimer>();
        buttonUI = player.GetComponentInChildren<PlayerInteractionBehavior>();

        isInteractable = false;
        canBePicked = false;
        isGrabbed = false;
        onBranch = false;
        Destroy(GetComponent<HingeJoint2D>());
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isFruit && !isMushroom && !isNut)
        //{
        //    // branches, etc.
        //}
        //else
        //{
        //    DetectInput();
        //}
        DetectInput();
    }

    void DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isGrabbed)
        {
            isGrabbed = false;
            Destroy(GetComponent<HingeJoint2D>());
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isInteractable && onBranch && isFruit)
            {
                ConsumeFruit();
            }

            if (canBePicked)
            {
                isGrabbed = true;
            }
        }
    }

    void ConsumeFruit()
    {
        sleepTimer.itemTimeMultiplier = sleepMultiplier;
        //this.GetComponent<ObjectTimer>().Init();
        this.gameObject.SetActive(false);
        Invoke("DestroyFruit", 2f);
    }

    void DestroyFruit()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && isGrabbed)
        {
            Rigidbody2D rb = collision.transform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                HingeJoint2D hj = transform.gameObject.AddComponent(typeof(HingeJoint2D)) as HingeJoint2D;
                hj.connectedBody = rb;
            }
            else
            {
                HingeJoint2D hj = transform.gameObject.AddComponent(typeof(HingeJoint2D)) as HingeJoint2D;
            }
        }
    }
}
