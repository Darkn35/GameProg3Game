using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingBehavior : MonoBehaviour
{
    [SerializeField] private SleepTimer TimeSlider;
    [SerializeField] private UIFadeInOut UIFade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            UIFade.ShowUI();
            TimeSlider.StartTime();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            UIFade.HideUI();
            TimeSlider.ResetTime();
        }
    }
}
