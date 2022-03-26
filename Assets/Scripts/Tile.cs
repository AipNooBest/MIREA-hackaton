using UnityEngine;

public class Tile : MonoBehaviour
{
    public float speed;
 
    private Vector3 destination;
    private bool selected;
    private bool moving;
    private Switcher switchHandler;
 
    void Start()
    {
        selected = false;
        SetDestination(gameObject.transform.position);
        switchHandler = GameObject.Find("SwitchHandler").GetComponent<Switcher>();
    }
     
    void Update() {
        if (destination != gameObject.transform.position) {
            IncrementPosition();
        } else if (moving) {
            moving = false;
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
        moving = true;
        destination = value;
    }

    public void Deselect()
    {
        selected = false;
        Vector3 position = gameObject.transform.position;
        SetDestination(new Vector3(position.x, 0.3f, position.z));
        switchHandler.DeselectTile();
    }
    
    public void Select()
    {
        selected = true;
        Vector3 position = gameObject.transform.position;
        SetDestination(new Vector3(position.x, 0.6f, position.z));
        switchHandler.SelectTile(this);
    }

    public void OnMouseUpAsButton()
    {
        Debug.Log("Clicked " + gameObject.name);
        if(selected)    Deselect();
        else            Select();
    }
    
    public bool IsMoving()
    {
        return moving;
    }
}
