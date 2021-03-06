using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    private static bool forMusic = false;
    private static bool firstRiddleSolved = false;
    private static bool secondRiddleSolved = false;
    
    public static void changeScene(int i) {
        if (i == 1 && firstRiddleSolved)
        {
            return;
        }
        if (i == 2 && secondRiddleSolved)
        {
            return;
        }

        if (i == 3)
        {
            if (!(firstRiddleSolved && secondRiddleSolved))
            {
                // Проигрывание звуков
                return;
            }
        }
        SceneManager.LoadScene(i);
    }
    public static bool GetMusic()
    {
        return forMusic;
    }
    public static void SetMusic(bool solved)
    {
        forMusic = solved;
    }
    public static bool GetFirstRiddleSolved()
    {
        return firstRiddleSolved;
    }
    
    public static bool GetSecondRiddleSolved()
    {
        return secondRiddleSolved;
    }
    
    public static void SetFirstRiddleSolved(bool solved)
    {
        firstRiddleSolved = solved;
    }
    
    public static void SetSecondRiddleSolved(bool solved)
    {
        secondRiddleSolved = solved;
    }
}
