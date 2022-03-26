using System.Collections;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    private Tile selectedTile;

    void SwitchTiles(Tile switchingTile)
    {
        if (selectedTile == switchingTile) return;
        StartCoroutine(SwitchTilesCoroutine(switchingTile));
    }
    
    public void SelectTile(Tile obj)
    {
        if(selectedTile == null)
            selectedTile = obj;
        else
            SwitchTiles(obj);
    }
    
    public void DeselectTile()
    {
        selectedTile = null;
    }
    
    private IEnumerator SwitchTilesCoroutine(Tile switchingTile)
    {
        Debug.Log("Switching tiles");
        while (switchingTile.IsMoving())
        {
            yield return null;
        }
        selectedTile.SetDestination(switchingTile.transform.position);
        switchingTile.SetDestination(selectedTile.transform.position);
        while (selectedTile.IsMoving() && switchingTile.IsMoving())
        {
            yield return null;
        }
        selectedTile.Deselect();
        switchingTile.Deselect();
        DeselectTile();
        Debug.Log("Switched tiles");
        
    }
}