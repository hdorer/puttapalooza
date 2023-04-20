using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionSettings : MonoBehaviour
{
    public TMP_Dropdown resDropdown;
    static bool fullscreen = true;
    float width = 1920, height = 1080;
    int currentOption = 0;

    void Start()
    {
        resDropdown.onValueChanged.AddListener(delegate {ChangeResolution(resDropdown.value);});
    }
    void Destroy()
    {
        resDropdown.onValueChanged.RemoveAllListeners();
    }
    private void ChangeResolution(int option)
    {
        Debug.Log("Current Option: "+option);
        switch(option)
        {
            //1920x1080
            case 0:
            Screen.SetResolution(1920, 1080, fullscreen);
            currentOption = 0;
            Display();
            break;
            //1280x720
            case 1:
            Screen.SetResolution(1280, 720, fullscreen);
            currentOption = 1;
            Display();
            break;
            //640x480
            case 2:
            Screen.SetResolution(640, 480, fullscreen);
            currentOption = 2;
            Display();
            break;
        }
    }
    public void fullscreenButton()
    {
        fullscreen = !fullscreen;
        ChangeResolution(currentOption);
    }
    public void Display()
    {
        switch(currentOption)
        {
           //1920x1080
            case 0:
            Debug.Log("Cur Res: 1920x1080, curOpt: "+currentOption+ "Fullscreen: "+fullscreen);
            break;
            //1280x720
            case 1:
            Debug.Log("Cur Res: 1280x720, curOpt: "+currentOption + "Fullscreen: "+fullscreen);
            break;
            //640x480
            case 2:
            Debug.Log("Cur Res: 640x480, curOpt: "+currentOption+ "Fullscreen: "+fullscreen);
            break; 
        }
    }
}
