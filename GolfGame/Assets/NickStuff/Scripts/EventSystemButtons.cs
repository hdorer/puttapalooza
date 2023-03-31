using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class EventSystemButtons : MonoBehaviour
{   
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject ControlPanel;
    [SerializeField] private GameObject PlayerPanel;
    void Start()
    {
        if(SceneChange.CheckScene() == 0)
        {
            MenuPanel.SetActive(true);
            SettingPanel.SetActive(false);
            ControlPanel.SetActive(false);
            PlayerPanel.SetActive(false);
        }
    }
    public void SwitchToSettings()
    {
        SettingPanel.SetActive(true);
        MenuPanel.SetActive(false);
        ControlPanel.SetActive(false);
    }
    public void SwitchToMain()
    {
        MenuPanel.SetActive(true);
        SettingPanel.SetActive(false);
        PlayerPanel.SetActive(false);
    }
    public void SwitchToControl()
    {
        SettingPanel.SetActive(false);
        ControlPanel.SetActive(true);
    }
    public void SwitchToPlayer()
    {
        PlayerPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }
    public void SwitchScene(int sceneNum)
    {
        SceneChange.SwitchToScene(sceneNum);
    }
    public void QuitGame()
    {
        // Debug.Log("Quit Game");
        SceneChange.QuitTheGame();
    }
}
