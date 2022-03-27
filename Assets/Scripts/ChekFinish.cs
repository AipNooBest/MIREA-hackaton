using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekFinish : MonoBehaviour
{
    [SerializeField] AudioSource PhonEveric2;
 
    // Update is called once per frame
    void Update()
    {
        if (!PhonEveric2.isPlaying) {
            Application.Quit();
        }
    }
}
