using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Will controll the adding of players
public class PlayerPanelController : MonoBehaviour
{
    static public int CurrentNumOfPlayers = 1;
    public List<GameObject> players;
    public void AddPlayer()
    {
        if(CurrentNumOfPlayers-1 != 3)
        {
            CurrentNumOfPlayers++;
            players[CurrentNumOfPlayers-1].SetActive(true);
        }
    }
    public void RemovePlayer()
    {
        if(CurrentNumOfPlayers-1 != 0)
        {
            players[CurrentNumOfPlayers-1].SetActive(false);
            CurrentNumOfPlayers--;
        }
    }
}
