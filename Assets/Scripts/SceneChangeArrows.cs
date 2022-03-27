using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneChangeArrows : MonoBehaviour, IPointerClickHandler
{
    public int numberScene;
    public void OnPointerClick(PointerEventData eventData)
    {
        Scene_Manager.changeScene(numberScene);
    }
}
