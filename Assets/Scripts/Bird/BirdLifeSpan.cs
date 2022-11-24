using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdLifeSpan : MonoBehaviour
{
    [SerializeField] private BirdFadeInAndOut birdFade;
    public GameObject birdGameObject;
    public float timeToDisappear;
    public float totalTime;
    [SerializeField] private bool isFading;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        totalTime = timeToDisappear;
        isFading = false;
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;

        if (totalTime <= 1f && !isFading)
        {
            isFading = true;
            StartCoroutine(birdFade.FadeOut());
        }

        if (totalTime <= 0)
        {
            Init();
            birdFade.ResetVal();
            birdGameObject.SetActive(false);
        }
    }
}
