using System.Collections;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    private Tile selectedTile;
    private bool busy;

    void SwitchTiles(Tile switchingTile)
    {
        if (selectedTile == switchingTile) return;
        busy = true;
        StartCoroutine(SwitchTilesCoroutine(switchingTile));
    }
    
    public void SelectTile(Tile obj)
    {
        if (selectedTile == null)
            selectedTile = obj;
        else
            SwitchTiles(obj);
    }
    
    public void DeselectTile() => selectedTile = null;
    
    public bool IsBusy() => busy;
    
    private bool AllTilesSet()
    {
        foreach (var tile in FindObjectsOfType<Tile>())
        {
            Debug.Log(tile.name + " " + tile.IsSet());
            if (tile.IsSet() == false)
                return false;
        }
        return true;
    }

    private IEnumerator SwitchTilesCoroutine(Tile switchingTile)
    {
        Debug.Log("Switching tiles");
        while (switchingTile.GetGlider().IsMoving())
            yield return null;
        
        selectedTile.Move(switchingTile.transform.position);
        switchingTile.Move(selectedTile.transform.position);
        while (selectedTile.GetGlider().IsMoving() && switchingTile.GetGlider().IsMoving())
            yield return null;
        
        int temp = selectedTile.currentPosition;
        selectedTile.currentPosition = switchingTile.currentPosition;
        switchingTile.currentPosition = temp;
        selectedTile.Deselect();
        switchingTile.Deselect();
        DeselectTile();
        Debug.Log("Switched tiles");
        busy = false;
        if (AllTilesSet())
        {
            Debug.Log("All tiles set");
            var cylinder = GameObject.Find("Cylinder");
            Vector3 tempPos = cylinder.transform.position;
            cylinder.GetComponent<Glider>().SetDestination(new Vector3(tempPos.x, tempPos.y + 3.3f, tempPos.z));
            StartCoroutine(TakeKey());
        }
    }

    private IEnumerator TakeKey()
    {
        yield return new WaitForSeconds(2);
        var key = GameObject.Find("Key");
        Destroy(key);
        Scene_Manager.SetFirstRiddleSolved(true);
        Scene_Manager.changeScene(0);
    }
}