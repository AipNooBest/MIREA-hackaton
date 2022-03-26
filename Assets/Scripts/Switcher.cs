public static class Switcher
{
    public static TileHandler selectedObject;

    public static void SwitchObjects(TileHandler switchingObject)
    {
        if (selectedObject == switchingObject) return;
        selectedObject.SetDestination(switchingObject.transform.position);
        selectedObject.Deselect();
        switchingObject.SetDestination(selectedObject.transform.position);
        switchingObject.Deselect();
        DeselectObject();
    }
    
    public static void SelectObject(TileHandler obj)
    {
        if(selectedObject == null)
        {
            selectedObject = obj;
        }
        else
        {
            SwitchObjects(obj);
            selectedObject = null;
        }
    }
    
    public static void DeselectObject()
    {
        selectedObject = null;
    }
}