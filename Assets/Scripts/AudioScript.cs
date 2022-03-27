using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
    
{
    private bool forMusic1;
    [SerializeField] private AudioSource audioEveric;
    [SerializeField] private AudioSource audioMusic;

    private void Awake()
    {
        if (Scene_Manager.GetMusic() == false)
        {
            audioEveric.Play();
            Scene_Manager.SetMusic(true);
        }
        
    }
    
    public void Update()
    {
        if ((!audioEveric.isPlaying)&(!audioMusic.isPlaying)) {
            audioMusic.Play();
        }
        
    }

}
