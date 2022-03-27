using UnityEngine;

public class Tile : MonoBehaviour
{
    public int correctPosition;
    public int currentPosition;
    
    private bool selected;
    private Switcher switchHandler;
    private Glider glider;
 
    void Start()
    {
        glider = gameObject.GetComponent<Glider>();
        selected = false;
        switchHandler = GameObject.Find("SwitchHandler").GetComponent<Switcher>();
    }

    // Set the destination to cause the object to smoothly glide to the specified location
    public void Move(Vector3 value)
    {
        glider.SetDestination(value);
    }

    public void Deselect()
    {
        selected = false;
        Vector3 position = gameObject.transform.position;
        Move(new Vector3(position.x, 0.3f, position.z));
        switchHandler.DeselectTile();
    }
    
    public void Select()
    {
        selected = true;
        Vector3 position = gameObject.transform.position;
        Move(new Vector3(position.x, 0.6f, position.z));
        switchHandler.SelectTile(this);
    }

    public void OnMouseUpAsButton()
    {
        Debug.Log("Clicked " + gameObject.name);
        if(selected)    Deselect();
        else            Select();
    }

    public bool IsSet()
    {
        return currentPosition == correctPosition;
    }
    
    public Glider GetGlider()
    {
        return glider;
    }
}
