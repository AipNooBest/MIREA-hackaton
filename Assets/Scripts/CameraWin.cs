using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWin : MonoBehaviour
{
    GameObject key;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private AudioSource backGroundMusic;
    private float timeToWin;
    private Camera cam;
    private bool flagWin;
    void Start()
    {
        flagWin = false;
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
            win();
        }


    }
    void win() {
        if (flagWin == false)
        {
            backGroundMusic.Stop();
            flagWin = true;
            winSound.Play();
        }
        else { 
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 131f, Time.deltaTime * 6);
            
        }
    }


}
