using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwistObject : MonoBehaviour
        
    
{
    public float timeToWin;
    Vector3 firstPoint;
    Vector3 secondPoint;
    float xAngel;
    float yAngel;
    float xAngelTemp;
    float yAngelTemp;
    // Start is called before the first frame update
    void Start()
    {
        timeToWin = 2.5f;
        yAngel = transform.localRotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches) {
            if (touch.position.x > 0 & touch.phase == TouchPhase.Began) {
                firstPoint = touch.position;
                xAngelTemp = xAngel;
                yAngelTemp = yAngel;
            }
            if (touch.position.x > 0 & touch.phase == TouchPhase.Moved) {
                secondPoint = touch.position;
                xAngel = xAngelTemp - (secondPoint.y - firstPoint.y)* 90 /Screen.height;
                yAngel = yAngelTemp + (secondPoint.x - firstPoint.x) * 180 / Screen.width;
                transform.rotation = Quaternion.Euler(xAngel, yAngel, 0);
            }
        }
        if (timeToWin > 0)
        {
            if ((transform.rotation.x * 100 < 2.662f) & (transform.rotation.x * 100 > -1.083f) & (transform.rotation.y * 100 < 3.537f) & (transform.rotation.y * 100 > -0.625f))
            {
                timeToWin -= Time.deltaTime;
            }
            else
            {
                timeToWin = 2.5f;
            }
        }
        else {
            print("Win!");
        }
        
    }
}
