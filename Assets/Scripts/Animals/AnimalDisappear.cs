using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDisappear : MonoBehaviour
{
    Camera cam;
    public float currentTime;
    public float maxTime;
    private SpriteFade spriteFade;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        spriteFade = GetComponent<SpriteFade>();
        Init();
    }

    public void Init()
    {
        currentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(this.gameObject.transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // Object is in camera
            currentTime = maxTime;
            spriteFade.ResetVal();
        }
        else
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                this.gameObject.SetActive(false);
            }
            else if (currentTime <= 1.5f)
            {
                StartCoroutine(spriteFade.FadeOut());
            }
        }
    }
}
