using UnityEngine;

public class SceneChangeArrows : MonoBehaviour
{
    public int numberScene;
    public void OnMouseUpAsButton()
    {
        Scene_Manager.changeScene(numberScene);
    }
}
