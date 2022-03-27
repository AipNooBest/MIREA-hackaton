using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour, IPointerClickHandler
{
    private GameObject mainCamera;
    public float x;
    public float y;
    public float z;
    private Vector3 newPos;

    public float xAng;
    public float yAng;
    public float zAng;


    private void Start()
    {
        newPos = new Vector3(x,y,z);

        mainCamera = GameObject.Find("Main Camera");
    }
    public void changePos() {
        mainCamera.transform.position = newPos;
        mainCamera.transform.rotation = Quaternion.Euler(xAng, yAng, zAng);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        changePos();
    }
}
