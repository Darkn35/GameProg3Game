using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTimer : MonoBehaviour
{
    [SerializeField] private SpriteFade objectFade;
    [SerializeField] private ObjectBehavior objBehavior;
    [SerializeField] private bool isFading;
    //[SerializeField] private FallingObjectsSpawn objectsSpawn;
    public GameObject gameObj;
    public float timeToDisappear;
    public float totalTime;
    public bool isInteractable;
    public string objectName;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public void Init()
    {
        totalTime = timeToDisappear;
        isFading = false;

        if (isInteractable)
        {
            objBehavior.Init();
            //objectsSpawn.SpawnObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;

        if (objectName == "Bird")
        {
            if (totalTime <= 1f && !isFading)
            {
                isFading = true;
                StartCoroutine(objectFade.FadeOut());
            }

            if (totalTime <= 0)
            {
                Init();
                objectFade.ResetVal();
                gameObj.SetActive(false);
            }
        }
        else if (objectName == "Interactable")
        {
            if (totalTime <= 1f && !isFading)
            {
                isFading = true;
                StartCoroutine(objectFade.FadeOut());
            }

            if (totalTime <= 0)
            {
                //Init();
                objectFade.ResetVal();
                //gameObj.SetActive(false);
                Destroy(this.gameObject);
            }
        }
       
    }
}
