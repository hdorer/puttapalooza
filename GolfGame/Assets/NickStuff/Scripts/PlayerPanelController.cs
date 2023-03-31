using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Will controll the adding of players
public class PlayerPanelController : MonoBehaviour
{
    private int currentNumOfPlayers = 1;
    private GameObject[] players;
    [SerializeField] private PerPlayerCustomize[] pOptions;
    
    public int CurrentNumOfPlayers { get => currentNumOfPlayers; }
    public PerPlayerCustomize[] POptions { get => pOptions; }

    public void AddPlayer()
    {
        if(currentNumOfPlayers-1 != 3)
        {
            currentNumOfPlayers++;
            players[currentNumOfPlayers-1].SetActive(true);
        }
    }
    public void RemovePlayer()
    {
        if(currentNumOfPlayers-1 != 0)
        {
            players[currentNumOfPlayers-1].SetActive(false);
            currentNumOfPlayers--;
        }
    }
}
