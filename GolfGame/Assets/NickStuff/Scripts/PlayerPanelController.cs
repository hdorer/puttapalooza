using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Will controll the adding of players
public class PlayerPanelController : MonoBehaviour
{
    int CurrentNumOfPlayers = 0;
    public List<GameObject> players;
    public void AddPlayer()
    {
        if(CurrentNumOfPlayers != 3)
        {
            CurrentNumOfPlayers++;
            players[CurrentNumOfPlayers].SetActive(true);
        }
    }
    public void RemovePlayer()
    {
        if(CurrentNumOfPlayers != 0)
        {
            players[CurrentNumOfPlayers].SetActive(false);
            CurrentNumOfPlayers--;
        }
    }
}
