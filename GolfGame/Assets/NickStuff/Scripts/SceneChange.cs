using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange
{
    public static void SwitchToScene(int n)
    {
        SceneManager.LoadScene(n);
    }
    public static void QuitTheGame()
    {
        Application.Quit();
    }
    public static int CheckScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
