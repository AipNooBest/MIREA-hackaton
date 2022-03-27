using UnityEngine;

public class CameraMove : MonoBehaviour
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
        if (newPos.Equals(new Vector3(0, 0, 0)))
        {
            if (!(Scene_Manager.GetFirstRiddleSolved() && Scene_Manager.GetSecondRiddleSolved()))
            {
                // Проигрывание звуков
                return;
            }
            else
            {
                
            }
        }
        mainCamera.transform.position = newPos;
        mainCamera.transform.rotation = Quaternion.Euler(xAng, yAng, zAng);

        GameObject text = GameObject.Find("Cypher");
        if (newPos.Equals(new Vector3(-3.593f, 2.65f, -1.703f)))
        {
            text.GetComponent<TextMesh>().text = "1D: Ѭ     3C: Ϡ\n2B: Ȣ       4A: Ԉ\n2E: Ɇ       5B: Ҩ";
        }
        else
        {
            text.GetComponent<TextMesh>().text = "";
        }
    }

    public void OnMouseUpAsButton()
    {
        changePos();
    }
}
