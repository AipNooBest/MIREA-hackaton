using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwistObject : MonoBehaviour
        
    
{
    Vector3 firstPoint;
    Vector3 secondPoint;
    float xAngel;
    float yAngel;
    float xAngelTemp;
    float yAngelTemp;
    // Start is called before the first frame update
    void Start()
    {
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
        
    }
}
