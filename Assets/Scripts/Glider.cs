using UnityEngine;

public class Glider : MonoBehaviour
{
    public float speed;
    
    private Vector3 destination;
    private bool moving;
    void Start()
    {
        SetDestination(gameObject.transform.position);
    }
     
    void Update() {
        if (destination != gameObject.transform.position)
            IncrementPosition();
        else if (moving)
            moving = false;
    }
 
    void IncrementPosition()
    {
        float delta = speed * Time.deltaTime;
        Vector3 transformPosition = transform.position;
        Vector3 nextPosition = Vector3.MoveTowards(transformPosition, destination, delta);
 
        transform.position = nextPosition;
    }
 
    public void SetDestination (Vector3 value)
    {
        moving = true;
        destination = value;
    }
    
    public bool IsMoving()
    {
        return moving;
    }
}