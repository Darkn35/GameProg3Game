using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCollision : MonoBehaviour
{
    [SerializeField] private SleepTimer timeSlider;
    [SerializeField] private UIFadeInOut UIFade;
    private BoxCollider2D boxCollider;

    public float timeMultiplier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            foreach(ContactPoint2D hitPos in collision.contacts)
            {
                if (hitPos.normal.y > 0)
                {
                    boxCollider.isTrigger = true;
                    return;
                }
            }
            UIFade.ShowUI();
            timeSlider.StartTime();
            timeSlider.sleepTimeMultiplier = timeMultiplier;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            boxCollider.isTrigger = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            UIFade.HideUI();
            timeSlider.ResetTime();
        }
    }
}
