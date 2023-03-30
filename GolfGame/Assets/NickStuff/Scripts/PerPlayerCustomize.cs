using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//This is used to customize the player
//Includes color, difficulty, and starting power
public class PerPlayerCustomize : MonoBehaviour
{
    [SerializeField] private int playerNum;
    public Image PlayerBall;
    public TMP_Dropdown difficultyDropdown, powerUpDropdown;
    int playerDifficulty;
    public Color playerColor;
    //
    void Start()
    {
        //Set color too thing
        difficultyDropdown.onValueChanged.AddListener(delegate {ChangeDifficulty(difficultyDropdown.value);});
        powerUpDropdown.onValueChanged.AddListener(delegate {ChangeDifficulty(powerUpDropdown.value);});
        PlayerBall.color = playerColor;
    }
    void Destroy()
    {
        difficultyDropdown.onValueChanged.RemoveAllListeners();
        powerUpDropdown.onValueChanged.RemoveAllListeners();
    }
    private void ChangeStartPowerup(int option)
    {
        //Nothing yet
    }
    private void ChangeDifficulty(int option)
    {
        switch(option)
        {
            case 0:
            Debug.Log("Easy");
            break;
            case 1:
            Debug.Log("Medium");
            break;
            case 2:
            Debug.Log("Hard");
            break;
        }
    }
    public void ChangeColor(int colorNum)
    {
        switch(colorNum)
        {
            //Red
            case 1:
            PlayerBall.color = Color.red;
            playerColor = Color.red;
            break;
            //Blue
            case 2:
            PlayerBall.color = Color.blue;
            playerColor = Color.blue;
            break;
            //Black
            case 3:
            PlayerBall.color = Color.black;
            playerColor = Color.black;
            break;
            //Green
            case 4:
            PlayerBall.color = Color.green;
            playerColor = Color.green;
            break;
            //Yellow
            case 5:
            PlayerBall.color = Color.yellow;
            playerColor = Color.yellow;
            break;
            //
            case 6:
            PlayerBall.color = Color.magenta;
            playerColor = Color.magenta;
            break;
        }
        //Send To thing
    }
}
