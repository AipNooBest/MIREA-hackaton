using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageQuit : MonoBehaviour
{
    [SerializeField] AudioSource quitMusic;
    void Start()
    {
        
    }


    void Update()
    {
        if (!quitMusic.isPlaying) {
            Application.Quit();
        }
        
    }
}
