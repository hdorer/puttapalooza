using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Will controll the adding of players
public class PlayerPanelController : MonoBehaviour
{
    private int currentNumOfPlayers = 1;
    [SerializeField] private PerPlayerCustomize[] pOptions;
    
    public int CurrentNumOfPlayers { get => currentNumOfPlayers; }
    public PerPlayerCustomize[] POptions { get => pOptions; }

    private void Awake() {
        GameManager.setPlayerPanel(this);
    }

    public void AddPlayer()
    {
        if(currentNumOfPlayers-1 != 3)
        {
            currentNumOfPlayers++;
            pOptions[currentNumOfPlayers-1].gameObject.SetActive(true);
        }
    }
    public void RemovePlayer()
    {
        if(currentNumOfPlayers-1 != 0)
        {
            pOptions[currentNumOfPlayers-1].gameObject.SetActive(false);
            currentNumOfPlayers--;
        }
    }
}
