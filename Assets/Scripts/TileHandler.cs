using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TileHandler : MonoBehaviour
{
    public float speed;
 
    private Vector3 destination;
    private bool selected;
 
    void Start()
    {
        selected = false;
        SetDestination(gameObject.transform.position);
    }
     
    void Update() {
        if (destination != gameObject.transform.position) {
            IncrementPosition();
        }
    }
 
    void IncrementPosition()
    {
        float delta = speed * Time.deltaTime;
        Vector3 currentPosition = transform.position;
        Vector3 nextPosition = Vector3.MoveTowards(currentPosition, destination, delta);
 
        transform.position = nextPosition;
    }
 
    // Set the destination to cause the object to smoothly glide to the specified location
    public void SetDestination (Vector3 value)
    {
        destination = value;
    }

    public void Deselect()
    {
        selected = false;
    }

    public void OnMouseUpAsButton()
    {
        Debug.Log("Clicked " + gameObject.name);
        if(selected)
        {
            selected = false;
            SetDestination(new Vector3(gameObject.transform.position.x, 0.3f, gameObject.transform.position.z));
            Switcher.DeselectObject();
        }
        else
        {
            selected = true;
            SetDestination(new Vector3(gameObject.transform.position.x, 0.6f, gameObject.transform.position.z));
            Switcher.SelectObject(this);
        }
    }
}
