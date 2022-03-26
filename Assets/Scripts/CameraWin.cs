using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWin : MonoBehaviour
{
    GameObject key;
    private float timeToWin;
    private Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.fieldOfView = 60f;
        key = GameObject.Find("key");
        timeToWin = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToWin > 0)
        {
            if ((key.transform.rotation.x * 100 < 2.662f) & (key.transform.rotation.x * 100 > -1.083f) & (key.transform.rotation.y * 100 < 3.537f) & (key.transform.rotation.y * 100 > -0.625f))
            {
                timeToWin -= Time.deltaTime;
            }
            else
            {
                timeToWin = 1.5f;
            }
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 131f, Time.deltaTime*6);

        }

    }
}
